using System;
using System.Threading.Tasks;

using time_ghost_app.ViewModels;

namespace time_ghost_app.Services
{
    public interface IUserDataService
    {
        event EventHandler<UserViewModel> UserDataUpdated;

        void Initialize();

        Task<UserViewModel> GetUserAsync();
    }
}
