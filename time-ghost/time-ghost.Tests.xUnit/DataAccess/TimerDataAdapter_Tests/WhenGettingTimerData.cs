using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using time_ghost.Core.Models;
using time_ghost.DataAccess;
using Xunit;

namespace time_ghost.Tests.DataAccess.TimerDataAdapter_Tests
{
    public class WhenGettingTimerData
    {
        [Fact]
        public async void Given_valid_id_Then_load_timer()
        {
            // Arrange
            var expectedTimerId = Guid.NewGuid();
            Timer expectedTimer = new Timer() { Id = expectedTimerId };
            var exptectedTimerJson = JsonConvert.SerializeObject(expectedTimer);

            var mockStorageManager = Substitute.For<IStorageManager>();
            mockStorageManager.LoadItemAsync(expectedTimerId).Returns(exptectedTimerJson);
            var sut = new TimerDataAdapter(mockStorageManager);

            // Act
            var actualTimer = await sut.GetTimerAsync(expectedTimerId);

            // Assert
            Assert.NotNull(actualTimer);
            Assert.Equal(expectedTimerId, actualTimer.Id);
        }

        public static IEnumerable<object[]> GetInvalidGuids()
        {
            yield return new object[] { null };
            yield return new object[] { Guid.Empty };
            yield return new object[] { Guid.NewGuid() };
        }

        [Theory]
        [MemberData(nameof(GetInvalidGuids))]
        public async void Given_invalid_id_Then_return_null(Guid timerId)
        {
            // Arrange
            var mockStorageManager = Substitute.For<IStorageManager>();
            mockStorageManager.LoadDataRawAsync().Returns("{\"timerData\": { \"timers\": []}}");
            var sut = new TimerDataAdapter(mockStorageManager);

            // Act
            var timer = await sut.GetTimerAsync(timerId);

            // Assert
            Assert.Null(timer);
        }
    }
}
