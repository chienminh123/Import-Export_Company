using Import_Export_Company.DTOs;
using Import_Export_Company.Models;
namespace Import_Export_Company.Services
{
    public interface IWareHouseService
    {  
        Task<IEnumerable<WareHouseDTO>> GetAllWareHousesAsync();
        Task<WareHouseDTO> GetWareHouseByIdAsync(int id);

        Task<WareHouseDTO> CreateWareHouseAsync(CreateWareHouse wareHouse);
        Task<WareHouseDTO> UpdateWareHouseAsync(int id, CreateWareHouse wareHouse);
        Task DeleteWareHouseAsync(int id);
    }
}
