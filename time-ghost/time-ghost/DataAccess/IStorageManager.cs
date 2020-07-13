using System;
using System.Threading.Tasks;
using time_ghost.Core.Models;

namespace time_ghost.DataAccess
{
    public interface IStorageManager
    {
        Task<string> LoadItem(Guid id);

        void InitializeStorage();
    }
}
