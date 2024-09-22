using Mapster;
using Wallet.Firebase.Api.Domain;
using Wallet.Firebase.Api.Models;
using Wallet.Firebase.Api.Models.Requests;
using Wallet.Firebase.Api.Models.Responses;
using Wallet.Firebase.Api.Repositories.Interfaces;
using Wallet.Firebase.Api.Services.Interfaces;

namespace Wallet.Firebase.Api.Services;

public class AccountService(IAccountRepository accountRepository) : IAccountService
{
    public async Task<IEnumerable<AccountResponse>> GetAccounts()
    {
        var accounts = await accountRepository.GetAccounts();
        return accounts.Adapt<AccountResponse[]>();
    }

    public async Task<AccountDetailsResponse> GetAccountDetails(string accountId)
    {
        var accountDetails = await accountRepository.GetAccountDetails(accountId);
        return accountDetails.Adapt<AccountDetailsResponse>();
    }

    public async Task<AccountTransactionsResponse> GetTransactions(string accountId)
    {
        var transactions = await accountRepository.GetAccountTransactions(accountId);
        return new AccountTransactionsResponse
        {
            AccountId = accountId,
            Transactions = transactions.Adapt<TransactionInfo[]>()
        };
    }

    // TODO: Need to do update
    public async Task<IdResponse> CreateTransaction(string accountId, CreateTransactionRequest request)
    {
        var transaction = request.Adapt<Transaction>();
        transaction.Id = accountId;
        var accountDetails = await accountRepository.GetAccountDetails(accountId);
        var idEntity = await accountRepository.CreateTransaction(accountId, transaction);

        var balance = GetUpdatedBalance(accountDetails.Balance, transaction.Amount, transaction.Type);
        await accountRepository.UpdateBalance(accountId, balance);

        return idEntity.Adapt<IdResponse>();
    }

    public async Task DeleteTransaction(string accountId, string transactionId)
    {
        var accountDetails = await accountRepository.GetAccountDetails(accountId);
        var transactionDetails = await accountRepository.GetTransactionDetails(accountId, transactionId);
        // amount with "-" sign to revert.
        await accountRepository.DeleteAccountTransaction(accountId, transactionId);

        var balance = GetUpdatedBalance(accountDetails.Balance, -transactionDetails.Amount, transactionDetails.Type);
        await accountRepository.UpdateBalance(accountId, balance);
    }

    private static double GetUpdatedBalance(double initialBalance, double amount, string transactionType) =>
        transactionType switch
        {
            "income" => initialBalance + amount,
            _ => initialBalance - amount
        };
}