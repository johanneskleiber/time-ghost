using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using time_ghost.Core.Models;

namespace time_ghost.DataAccess
{
    public class TimerDataAdapter : ITimerDataAdapter
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

            return JsonConvert.DeserializeObject<Timer>(await this.StorageManager.LoadItemAsync(timerId));
        }

        public async void SetTimerAsync(Timer timer)
        {
            if (timer == null|| timer.Id == null || timer.Id == Guid.Empty)
            {
                return;
            }

            this.StorageManager.SetItemAsync(JsonConvert.SerializeObject(timer));
        }
    }
}
