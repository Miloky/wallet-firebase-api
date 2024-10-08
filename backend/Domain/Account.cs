using Google.Cloud.Firestore;

namespace Wallet.Firebase.Api.Domain;

[FirestoreData]
public class Account
{
    [FirestoreDocumentId]
    public string Id { get; set; }

    //TODO: Should the name be unique?
    [FirestoreProperty(Name = "name")]
    public string Name { get; set; }

    // Currency code is immutable and will never be changed for account.
    [FirestoreProperty(Name = "currencyCode")]
    public string CurrencyCode { get; set; }

    // TODO: This is not ok to store money in double, we will loose precision 
    // TODO: Think about using int or long 
    [FirestoreProperty(Name = "balance")]
    public double Balance { get; set; }

    [FirestoreProperty("logo")]
    public string Logo { get; set; }
}