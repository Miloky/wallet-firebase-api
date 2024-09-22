namespace Wallet.Firebase.Api.Models.Responses;

public class AccountResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CurrencyCode { get; set; }

    // TOOD: Change on decimal
    public double Balance { get; set; }
}