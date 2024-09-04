using Google.Cloud.Firestore;
using Microsoft.Extensions.Options;
using Wallet.Firebase.Api.Models.Settings;

namespace Wallet.Firebase.Api;

public abstract class BaseRepository
{
    protected readonly FirestoreDb Store;

    protected BaseRepository(IOptions<FirebaseSettings> firebaseSettings)
    {
        Store = FirestoreDb.Create(firebaseSettings.Value.ProjectName);
    }
}