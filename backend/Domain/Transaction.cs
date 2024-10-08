using Google.Cloud.Firestore;
using Wallet.Firebase.Api.FirestoreConverters;

namespace Wallet.Firebase.Api.Domain;

[FirestoreData]
public class Transaction
{
    [FirestoreDocumentId]
    public string Id { get; set; }

    [FirestoreProperty("description")]
    public string Description { get; set; }

    // This amount is always in account currency.
    // TODO: Add additional field which will contain information about currency and exchange rate, for cases when payment made in different currency.
    [FirestoreProperty("amount")]
    public double Amount { get; set; }

    [FirestoreProperty("type", ConverterType = typeof(TransactionTypeConverter))]
    public TransactionType Type { get; set; }

    public DateTime TransactionDate { get; set; }
}