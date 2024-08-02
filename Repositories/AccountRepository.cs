using Google.Cloud.Firestore;
using Wallet.Firebase.Api.Domain;
using Wallet.Firebase.Api.Repositories.Interfaces;
using Transaction = Wallet.Firebase.Api.Domain.Transaction;

namespace Wallet.Firebase.Api.Repositories;

public class AccountRepository : BaseRepository, IAccountRepository
{
    public async Task<Account> GetAccountDetails(string accountId)
    {
        var path = GetAccountPath(accountId);
        var documentRef = Store.Document(path);
        var documentSnapshot = await documentRef.GetSnapshotAsync();
        if (!documentSnapshot.Exists)
        {
            throw new ArgumentOutOfRangeException(nameof(accountId));
        }

        return documentSnapshot.ConvertTo<Account>();
    }

    public async Task<Transaction> GetTransactionDetails(string accountId, string transactionId)
    {
        var path = GetTransactionPath(accountId, transactionId);
        var documentRef = Store.Document(path);
        var documentSnapshot = await documentRef.GetSnapshotAsync();
        return documentSnapshot.ConvertTo<Transaction>();
    }

    public async Task<IEnumerable<Transaction>> GetAccountTransactions(string accountId)
    {
        var path = GetTransactionCollectionPath(accountId);
        Query query = Store.Collection(path);
        var querySnapshot = await query.GetSnapshotAsync();
        var result = new List<Transaction>();
        foreach (var snapshot in querySnapshot)
        {
            if (!snapshot.Exists) continue;
            var data = snapshot.ConvertTo<Transaction>();
            result.Add(data);
        }

        return result;
    }

    public async Task<IdEntity> CreateTransaction(string accountId, Transaction transaction)
    {
        var transactionCollectionPath = GetTransactionCollectionPath(accountId);
        var transactionCollectionRef = Store.Collection(transactionCollectionPath);
        var transactionRef = await transactionCollectionRef.AddAsync(transaction);
        return new IdEntity(transactionRef.Id);
    }

    public async Task UpdateBalance(string accountId, double balanceAmount)
    {
        var accountPath = GetAccountPath(accountId);
        var accountRef = Store.Document(accountPath);
        await accountRef.UpdateAsync(new Dictionary<string, object> { { "balance", balanceAmount } });
    }
    
    public async Task DeleteAccountTransaction(string accountId, string transactionId)
    {
        var transactionPath = GetTransactionPath(accountId, transactionId);
        var docRef = Store.Document(transactionPath);
        await docRef.DeleteAsync();
    }
    
    private string GetAccountPath(string accountId) => $"accounts/{accountId}";
    private string GetTransactionCollectionPath(string accountId) => $"accounts/{accountId}/transactions";
    private string GetTransactionPath(string accountId, string transactionId) =>
        $"accounts/{accountId}/transactions/{transactionId}";
}