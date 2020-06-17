using System;
using System.Threading.Tasks;

using time_ghost_app.Core.Models;

namespace time_ghost_app.Core.Services
{
    public interface IMicrosoftGraphService
    {
        Task<User> GetUserInfoAsync(string accessToken);

        Task<string> GetUserPhoto(string accessToken);
    }
}
