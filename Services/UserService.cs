using Import_Export_Company.Data;
using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;
using Import_Export_Company.Models;
using Import_Export_Company.Repositories;

namespace Import_Export_Company.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;

        public UserService(IUserRepository userRepository, AppDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                FullName = u.FullName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Department = u.Department,
                Status = u.Status,
                Created_at = u.Created_at,
                Roles = u.UserRoles.Select(ur => ur.Role.Role_name).ToList()
            });
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("USER_NOT_FOUND");
            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Department = user.Department,
                Status = user.Status,
                Created_at = user.Created_at,
                Roles = user.UserRoles.Select(ur => ur.Role.Role_name).ToList()
            };
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserDTO dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var exitingUser = await _userRepository.GetByUsernameAsync(dto.UserName);
                if (exitingUser != null) throw new Exception("USERNAME_EXISTS");

                var user = new Users
                {
                    UserName = dto.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    FullName = dto.FullName,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    Department = dto.Department,
                    Status = "Active",
                    Created_at = DateTime.UtcNow
                };

                foreach (var roleId in dto.RoleIds)
                {
                    user.UserRoles.Add(new UserRole { RoleId = roleId });
                }

                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();
                await transaction.CommitAsync();

                return await GetUserByIdAsync(user.Id);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UpdateUserDTO dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null) throw new Exception("USER_NOT_FOUND");

                user.FullName = dto.FullName;
                user.Email = dto.Email;
                user.PhoneNumber = dto.PhoneNumber;
                user.Department = dto.Department;

                _context.Set<UserRole>().RemoveRange(user.UserRoles);

                foreach (var roleId in dto.RoleIds)
                {
                    user.UserRoles.Add(new UserRole { RoleId = roleId });
                }
                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();
                await transaction.CommitAsync();
                return await GetUserByIdAsync(user.Id);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeactivateUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("USER_NOT_FOUND");

            user.Status = "Inactive";
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task ResetPasswordAsync(int id, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("USER_NOT_FOUND");

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task ChangePasswordAsync(int currentUserId, ChangePasswordDTO dto)
        {
            var user = await _userRepository.GetByIdAsync(currentUserId);
            if (user == null) throw new Exception("USER_NOT_FOUND");

            if (!BCrypt.Net.BCrypt.Verify(dto.OldPassword, user.Password))
            {
                throw new Exception("WRONG_PASSWORD");
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
