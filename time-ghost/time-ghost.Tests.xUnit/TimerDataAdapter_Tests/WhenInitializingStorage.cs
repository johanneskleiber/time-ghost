using System;
using System.Collections.Generic;
using System.Text;
using time_ghost.DataAccess;
using Xunit;

namespace time_ghost.Tests.TimerDataAdapter_Tests
{
    public class WhenInitializingStorage
    {
        [Fact]
        public async void Then_create_an_empty_json_file()
        {
            // Arrange
            var sut = new TimerDataAdapter();

            // Act
            sut.InitializeStorage();

            // Assert
            Windows.Storage.StorageFolder roamingFolder =
                Windows.Storage.ApplicationData.Current.RoamingFolder;

            Assert.Equal("{\"timerData\": { \"timers\": []}}", await sut.LoadDataRawAsync());
        }
    }
}
