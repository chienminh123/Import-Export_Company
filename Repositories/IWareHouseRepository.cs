using Import_Export_Company.DTOs;
using Import_Export_Company.Models;
namespace Import_Export_Company.Repositories
{
    public interface IWareHouseRepository
    {
        Task<IEnumerable<WareHouses>> GetAllAsync();
        Task<WareHouses> GetByIdAsync(int id);
        Task<WareHouses> GetByNameAsync(string name);
        Task AddAsync(WareHouses wareHouse);
        void UpdateAsync(WareHouses wareHouse);
        void DeleteAsync(WareHouses wareHouse);
        Task SaveChangesAsync();
    }
}
