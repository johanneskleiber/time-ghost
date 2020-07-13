using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
            
            var timerId = Guid.NewGuid();
            var mockStorageManager = Substitute.For<IStorageManager>();
            mockStorageManager.LoadItem(timerId).Returns(
                "{\"timerData\": { \"timers\": [ {\"id\": \"" + timerId + "\"} ]}}"
            );
            var sut = new TimerDataAdapter(mockStorageManager);

            // Act
            var timer = await sut.GetTimerAsync(timerId);

            // Assert
            Assert.NotNull(timer);
            Assert.Equal(timerId, timer.Id);
        }

        public static IEnumerable<object[]> GetInvalidGuids()
        {
            yield return new object[] { null };
            yield return new object[] { Guid.Empty };
        }

        [Theory]
        [MemberData(nameof(GetInvalidGuids))]
        public async void Given_invalid_id_Then_return_null(Guid timerId)
        {
            // Arrange
            var sut = new TimerDataAdapter();

            // Act
            var timer = await sut.GetTimerAsync(timerId);

            // Assert
            Assert.Null(timer);
        }
    }
}
