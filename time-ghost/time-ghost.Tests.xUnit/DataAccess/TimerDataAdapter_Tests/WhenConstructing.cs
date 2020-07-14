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
    public class WhenConstructing
    {
        [Fact]
        public void Then_StorageManager_Shall_Be_Initialized()
        {
            // Arrange

            // Act
            var sut = new TimerDataAdapter();

            // Assert
            Assert.NotNull(sut.StorageManager);
            Assert.IsType<StorageManager>(sut.StorageManager);
        }

        [Fact]
        public void Given_storageManager_Then_StorageManager_Shall_Return_Same_Obejct()
        {
            // Arrange
            var storageManager = Substitute.For<IStorageManager>();

            // Act
            var sut = new TimerDataAdapter(storageManager);

            // Assert
            Assert.NotNull(sut.StorageManager);
            Assert.Same(storageManager, sut.StorageManager);
        }
    }
}
