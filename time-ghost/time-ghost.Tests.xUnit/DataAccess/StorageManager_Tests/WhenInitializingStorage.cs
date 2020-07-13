using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using time_ghost.DataAccess;
using Xunit;

namespace time_ghost.Tests.DataAccess.StorageManager_Tests
{
    public class WhenInitializingStorage
    {
        [Fact]
        public async void Then_create_an_empty_json_file()
        {
            // Arrange
            var sut = new StorageManager();

            // Act
            sut.InitializeStorage();

            // Assert
            Assert.Equal("{\"timerData\": { \"timers\": []}}", await sut.LoadDataRawAsync());
        }
    }
}
