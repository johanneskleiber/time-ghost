using System;
using System.Threading.Tasks;
using time_ghost.Core.Models;

namespace time_ghost.DataAccess
{
    public interface ITimerDataAdapter
    {
        IStorageManager StorageManager { get; }

        Task<Timer> GetTimerAsync(Guid timerId);
        void SetTimerAsync(Timer timer);
    }
}
