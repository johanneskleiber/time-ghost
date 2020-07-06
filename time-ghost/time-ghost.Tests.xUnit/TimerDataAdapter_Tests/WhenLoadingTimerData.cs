using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using time_ghost.DataAccess;
using Xunit;

namespace time_ghost.Tests.TimerDataAdapter_Tests
{
    public class WhenLoadingTimerData
    {
        [Fact]
        public void Given_valid_id_Then_load_timer()
        {
            // Arrange
            var sut = new TimerDataAdapter();
            var timerId = Guid.NewGuid();

            // Act
            var timer = sut.Load(timerId);

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
        public void Given_invalid_id_Then_return_null(Guid timerId)
        {
            // Arrange
            var sut = new TimerDataAdapter();

            // Act
            var timer = sut.Load(timerId);

            // Assert
            Assert.Null(timer);
        }
    }
}
