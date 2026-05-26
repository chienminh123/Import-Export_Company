using Import_Export_Company.Models;

namespace Import_Export_Company.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customers>> GetAllAsync();
        Task<Customers> GetByIdAsync(int id);
        Task<Customers> GetByCustomerNameAsync(string name);
        Task AddAsync(Customers customer);
        void UpdateAsync(Customers customer);
        void DeleteAsync(Customers customer);
        Task SaveChangesAsync();
    }
}
