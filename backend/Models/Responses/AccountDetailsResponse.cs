namespace Wallet.Firebase.Api.Models.Responses;

public class AccountDetailsResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string CurrencyCode { get; set; }
    public double Balance { get; set; }
}