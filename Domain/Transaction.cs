using Google.Cloud.Firestore;

namespace Wallet.Firebase.Api.Domain;

[FirestoreData]
public class Transaction
{
    [FirestoreDocumentId]
    public string Id { get; set; }
    
    [FirestoreProperty("amount")] 
    public double Amount { get; set; }
    
    [FirestoreProperty("description")] 
    public string Description { get; set; }
    
    [FirestoreProperty("type")] 
    public string Type { get; set; }
    
    // TODO: add labels
    // [Firestore]
    // public string[] Labels { get; set; }
}