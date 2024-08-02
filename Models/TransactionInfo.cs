namespace Wallet.Firebase.Api.Models;

public class TransactionInfo
{
    public string Id { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    
    // TODO: Change to enum with mapping on string, so that db will store a string 
    public string Type { get; set; }
}