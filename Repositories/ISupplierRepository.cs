using Import_Export_Company.DTOs;
using Import_Export_Company.Models;

namespace Import_Export_Company.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Suppliers>> GetAllAsync();
        Task<Suppliers> GetByIdAsync(int id);
        Task<Suppliers> GetByCompanyNameAsync(string name);
        Task AddAsync(Suppliers supplier);
        void UpdateAsync(Suppliers supplier);
        void DeleteAsync(Suppliers supplier);
        Task SaveChangesAsync();
    }
}
