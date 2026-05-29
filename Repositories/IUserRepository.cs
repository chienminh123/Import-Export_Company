using Import_Export_Company.Models;

namespace Import_Export_Company.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(int id);
        Task<Users> GetByUsernameAsync(string username);
        Task AddAsync(Users user);
        void Update(Users user);
        Task SaveChangesAsync();
    }
}
