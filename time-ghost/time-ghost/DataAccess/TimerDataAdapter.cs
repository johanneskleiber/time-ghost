using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using time_ghost.Core.Models;
using Windows.Storage;
using Windows.Storage.Streams;

namespace time_ghost.DataAccess
{
    public class TimerDataAdapter
    {
        public IStorageManager StorageManager { get; private set; }

        public TimerDataAdapter(IStorageManager storageManager = null)
        {
            this.StorageManager = storageManager ?? new StorageManager();
        }

        public async Task<Timer> GetTimerAsync(Guid timerId)
        {
            if (timerId == null || Guid.Empty == timerId)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Timer>(
                await this.StorageManager.LoadItem(timerId));
        }
    }
}
