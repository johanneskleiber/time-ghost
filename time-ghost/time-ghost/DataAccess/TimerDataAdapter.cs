using System;
using System.Threading.Tasks;
using time_ghost.Core.Models;
using Windows.Storage;
using Windows.Storage.Streams;

namespace time_ghost.DataAccess
{
    public class TimerDataAdapter
    {
        private const string TIMER_STORAGE_FILE_NAME = "timerStorage.json";

        private StorageFolder RoamingFolder { get { return ApplicationData.Current.RoamingFolder; } }

        public async void InitializeStorage()
        {
            if (await RoamingFolder.TryGetItemAsync(TIMER_STORAGE_FILE_NAME) == null)
            {
                var emptyFile = await RoamingFolder.CreateFileAsync(
                    TIMER_STORAGE_FILE_NAME,
                    CreationCollisionOption.FailIfExists);
                await FileIO.WriteTextAsync(emptyFile, "{\"timerData\": { \"timers\": []}}");
            }
        }

        public Timer Load(Guid timerId)
        {
            if (timerId == null || Guid.Empty == timerId)
            {
                return null;
            }

            // TODO 

            return new Timer { Id = timerId };
        }

        internal async Task<string> LoadDataRawAsync()
        {
            var timerStorageFile = await RoamingFolder.GetFileAsync(TIMER_STORAGE_FILE_NAME);
            return await FileIO.ReadTextAsync(timerStorageFile);
        }
    }
}
