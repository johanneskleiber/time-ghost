using System;
using System.Threading.Tasks;

namespace time_ghost.DataAccess
{
    public interface IStorageManager
    {
        Task<string> LoadItemAsync(Guid id);

        Task<string> LoadDataRawAsync();

        void SetItemAsync(string item);

        void InitializeStorage();
    }
}
