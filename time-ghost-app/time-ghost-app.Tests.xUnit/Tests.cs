using System;

using time_ghost_app.Core.Services;
using time_ghost_app.Services;
using time_ghost_app.ViewModels;

using Xunit;

namespace time_ghost_app.Tests.XUnit
{
    // TODO WTS: Add appropriate tests
    public class Tests
    {
        [Fact]
        public void TestMethod1()
        {
        }

        // TODO WTS: Add tests for functionality you add to MainViewModel.
        [Fact]
        public void TestMainViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new MainViewModel();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to SettingsViewModel.
        [Fact]
        public void TestSettingsViewModelCreation()
        {
            var identityService = new IdentityService();
            var microsoftGraphService = new MicrosoftGraphService();
            var userDataService = new UserDataService(identityService, microsoftGraphService);

            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new SettingsViewModel(identityService, userDataService);
            Assert.NotNull(vm);
        }
    }
}
