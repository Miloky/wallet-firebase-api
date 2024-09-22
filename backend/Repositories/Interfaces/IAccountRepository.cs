using Wallet.Firebase.Api.Domain;

namespace Wallet.Firebase.Api.Repositories.Interfaces;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAccounts();
    Task<Account> GetAccountDetails(string accountId);
    Task<IEnumerable<Transaction>> GetAccountTransactions(string accountId);
    Task<IdEntity> CreateTransaction(string accountId, Transaction transaction);
    Task UpdateBalance(string accountId, double balance);
    Task DeleteAccountTransaction(string accountId, string transactionId);
    Task<Transaction> GetTransactionDetails(string accountId, string transactionId);
}