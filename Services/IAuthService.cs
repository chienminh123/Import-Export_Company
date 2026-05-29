using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;

namespace Import_Export_Company.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> AuthenticateAsync(LoginRequestDTO request);
    }
}
