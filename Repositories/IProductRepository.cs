using Import_Export_Company.Models;

namespace Import_Export_Company.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(int id);
        Task<Products> GetBySkuAsync(string sku);
        Task AddAsync(Products product);
        void UpdateAsync(Products product);
        void DeleteAsync(Products product);
        Task SaveChangesAsync();

    }
}
