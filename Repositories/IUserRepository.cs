using Import_Export_Company.Models;

namespace Import_Export_Company.Repositories
{
    public interface IUserRepository
    {
        Task<Users> GetByUsernameAsync(string username);
    }
}
