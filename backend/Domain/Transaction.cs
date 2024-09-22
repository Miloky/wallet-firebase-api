using Google.Cloud.Firestore;
using Wallet.Firebase.Api.FirestoreConverters;

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

    [FirestoreProperty("type", ConverterType = typeof(TransactionTypeConverter))]
    public TransactionType Type { get; set; }
}