using Google.Cloud.Firestore;
using Wallet.Firebase.Api.Domain;

namespace Wallet.Firebase.Api.FirestoreConverters;

public class TransactionTypeConverter : IFirestoreConverter<TransactionType>
{
    public object ToFirestore(TransactionType value)
    {
        return Enum.GetName(value);
    }

    public TransactionType FromFirestore(object value)
    {
        var transactionTypeName = value.ToString();
        if (Enum.TryParse(transactionTypeName, out TransactionType transactionType))
        {
            return transactionType;
        }

        throw new InvalidCastException($"Cannot convert {transactionTypeName} to TransactionType");
    }
}