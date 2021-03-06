﻿using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace time_ghost.DataAccess
{
    internal class StorageManager : IStorageManager
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

        public async Task<string> LoadItemAsync(Guid id)
        {
            var timerData = await LoadDataRawAsync();
            var jTimerData = JObject.Parse(timerData);
            var idString = id.ToString();


            return (
                from t in jTimerData["timerData"]["timers"]
                where (string)t["id"] == idString
                select t.ToString()
            ).FirstOrDefault();
        }

        public virtual async Task<string> LoadDataRawAsync()
        {
            var timerStorageFile = await RoamingFolder.GetFileAsync(TIMER_STORAGE_FILE_NAME);
            return await FileIO.ReadTextAsync(timerStorageFile);
        }

        public void SetItemAsync(string item)
        {
            throw new NotImplementedException();
        }
    }
}
