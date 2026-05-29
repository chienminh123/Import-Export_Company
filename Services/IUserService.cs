using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;

namespace Import_Export_Company.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> CreateUserAsync(CreateUserDTO dto);
        Task<UserDTO> UpdateUserAsync(int id, UpdateUserDTO dto);
        Task DeactivateUserAsync(int id);
        Task ResetPasswordAsync(int id, string newPassword);
        Task ChangePasswordAsync(int currentUserId, ChangePasswordDTO dto);
    }
}
