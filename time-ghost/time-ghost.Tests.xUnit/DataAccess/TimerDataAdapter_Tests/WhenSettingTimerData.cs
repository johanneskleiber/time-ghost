using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using time_ghost.Core.Models;
using time_ghost.DataAccess;
using Xunit;

namespace time_ghost.Tests.DataAccess.TimerDataAdapter_Tests
{
    public class WhenSettingTimerData
    {
        public static IEnumerable<object[]> GetInvalidTimers()
        {
            yield return new object[] { null };
            yield return new object[] { new Timer() };
            yield return new object[] { new Timer() { Id = Guid.Empty } };
        }

        [Theory]
        [MemberData(nameof(GetInvalidTimers))]
        public void Given_invalid_timer_Then_StorageManager_will_not_be_called(Timer timer)
        {
            // Arrange
            var mockStorageManager = Substitute.For<IStorageManager>();
            var sut = new TimerDataAdapter(mockStorageManager);

            // Act
            sut.SetTimerAsync(timer);

            // Assert
            mockStorageManager.DidNotReceiveWithAnyArgs().SetItemAsync(default);
        }

        [Fact]
        public void Given_valid_timer_object_Then_StorageManager_will_be_called()
        {
            // Arrange
            var mockStorageManager = Substitute.For<IStorageManager>();
            var sut = new TimerDataAdapter(mockStorageManager);
            var timer = new Timer() { Id = Guid.NewGuid() };

            // Act
            sut.SetTimerAsync(timer);

            // Assert
            mockStorageManager.ReceivedWithAnyArgs().SetItemAsync(default);
        }
    }
}
