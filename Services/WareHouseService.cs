using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;
using Import_Export_Company.Models;
using Import_Export_Company.Repositories;

namespace Import_Export_Company.Services
{
    public class WareHouseService : IWareHouseService
    {
        private readonly IWareHouseRepository _wareHouseRepository;
        public WareHouseService(IWareHouseRepository wareHouseRepository)
        {
            _wareHouseRepository = wareHouseRepository;
        }

        public async Task<IEnumerable<WareHouseDTO>> GetAllWareHousesAsync()
        {
            var wareHouses = await _wareHouseRepository.GetAllAsync();
            return wareHouses.Select(w => new WareHouseDTO
            {
                Id = w.Id,
                Name = w.Name,
                PhoneNumber = w.PhoneNumber,
                Address = w.Address
            });
        }

        public async Task<WareHouseDTO> GetWareHouseByIdAsync(int id)
        {
            var wareHouse = await _wareHouseRepository.GetByIdAsync(id);
            if (wareHouse == null) throw new Exception("Warehouse not found.");
            return new WareHouseDTO
            {
                Id = wareHouse.Id,
                Name = wareHouse.Name,
                PhoneNumber = wareHouse.PhoneNumber,
                Address = wareHouse.Address
            };
        }
        public async Task<WareHouseDTO> CreateWareHouseAsync(CreateWareHouse wareHouse)
        {
            var existingProduct = await _wareHouseRepository.GetByNameAsync(wareHouse.Name);
            if (existingProduct != null)
            {
                throw new Exception("Warehouse name already exists.");
            }
            var newWareHouse = new WareHouses
            {
                Name = wareHouse.Name,
                PhoneNumber = wareHouse.PhoneNumber,
                Address = wareHouse.Address
            };
            await _wareHouseRepository.AddAsync(newWareHouse);
            await _wareHouseRepository.SaveChangesAsync();
            var createdWareHouse = await _wareHouseRepository.GetByNameAsync(wareHouse.Name);
            return new WareHouseDTO
            {
                Id = createdWareHouse.Id,
                Name = createdWareHouse.Name,
                PhoneNumber = createdWareHouse.PhoneNumber,
                Address = createdWareHouse.Address
            };
        }
        public async Task<WareHouseDTO> UpdateWareHouseAsync(int id, CreateWareHouse wareHouse)
        {
            var existingWareHouse = await _wareHouseRepository.GetByIdAsync(id);
            if (existingWareHouse == null)
            {
                throw new Exception("Warehouse not found.");
            }

            if (existingWareHouse.Name != wareHouse.Name)
            {
                var wareHouseWithName = await _wareHouseRepository.GetByNameAsync(wareHouse.Name);
                if (wareHouseWithName != null) throw new Exception("Warehouse with the same name already exists.");
            } 
            
            existingWareHouse.Name = wareHouse.Name;
            existingWareHouse.PhoneNumber = wareHouse.PhoneNumber;
            existingWareHouse.Address = wareHouse.Address;

            _wareHouseRepository.UpdateAsync(existingWareHouse);
            await _wareHouseRepository.SaveChangesAsync();

                return new WareHouseDTO
                {
                    Id = existingWareHouse.Id,
                    Name = existingWareHouse.Name,
                    PhoneNumber = existingWareHouse.PhoneNumber,
                    Address = existingWareHouse.Address
                };
        }

        public async Task DeleteWareHouseAsync(int id)
        {
            var existingWareHouse = await _wareHouseRepository.GetByIdAsync(id);
            if (existingWareHouse == null) throw new Exception("Warehouse not found.");

            _wareHouseRepository.DeleteAsync(existingWareHouse);
            await _wareHouseRepository.SaveChangesAsync();
        }
    }
}
