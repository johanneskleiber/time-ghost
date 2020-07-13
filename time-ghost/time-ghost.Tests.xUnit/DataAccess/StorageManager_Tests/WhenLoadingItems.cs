using Newtonsoft.Json.Linq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using time_ghost.DataAccess;
using Xunit;

namespace time_ghost.Tests.xUnit.DataAccess.StorageManager_Tests
{
    public class WhenLoadingItems
    {
        [Fact]
        public async void Given_valid_id_Then_item_is_returned()
        {
            // Arrange
            var sut = Substitute.ForPartsOf<StorageManager>();
            var expectedId = Guid.NewGuid();
            sut.LoadDataRawAsync().Returns(
                "{\"timerData\": { \"timers\": [ {\"id\": \"" + expectedId + "\"} ]}}"
            );

            // Act
            var timerJson = await sut.LoadItem(expectedId);
            var jTimer = JObject.Parse(timerJson);
            var actualId = (string)jTimer["id"];

            // Assert
            Assert.Equal(expectedId.ToString(), actualId);
        }
    }
}
