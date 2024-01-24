using Application.Common.Models.Auth;

namespace Application.Common.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(AuthRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
