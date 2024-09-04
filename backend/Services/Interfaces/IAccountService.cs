using Wallet.Firebase.Api.Models.Requests;
using Wallet.Firebase.Api.Models.Responses;

namespace Wallet.Firebase.Api.Services.Interfaces;

public interface IAccountService
{
    Task<AccountDetailsResponse> GetAccountDetails(string accountId);
    Task<AccountTransactionsResponse> GetTransactions(string accountId);
    Task<IdResponse> CreateTransaction(string accountId, CreateTransactionRequest transactionRequest);
    Task DeleteTransaction(string accountId, string transactionId);
}