namespace Wallet.Firebase.Api.Models.Responses;

public class AccountTransactionsResponse
{
    public string AccountId { get; set; }
    public IEnumerable<TransactionInfo> Transactions { get; set; }
}