namespace Wallet.Firebase.Api.Models.Requests;

public class CreateTransactionRequest
{
    public double Amount { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
}