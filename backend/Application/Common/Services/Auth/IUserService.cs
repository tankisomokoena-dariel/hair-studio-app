using Application.Common.Models.Auth;

namespace Application.Common.Services.Auth
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string userId);
    }
}
