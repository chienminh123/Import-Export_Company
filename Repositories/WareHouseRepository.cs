using Import_Export_Company.Data;
using Import_Export_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Repositories
{
    public class WareHouseRepository: IWareHouseRepository
    {
        private readonly AppDbContext _context;
        public WareHouseRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<WareHouses>> GetAllAsync()
        {
            return await _context.WareHouses.ToListAsync();
        }

        public async Task<WareHouses> GetByIdAsync(int id)
        {
            return await _context.WareHouses.FindAsync(id);
        }

        public async Task<WareHouses> GetByNameAsync(string name)
        {
            return await _context.WareHouses.FirstOrDefaultAsync(w => w.Name == name);
        }

        public async Task AddAsync(WareHouses wareHouse)
        {
            await _context.WareHouses.AddAsync(wareHouse);
        }

        public void UpdateAsync(WareHouses wareHouse)
        {
            _context.WareHouses.Update(wareHouse);
        }

        public void DeleteAsync(WareHouses wareHouse)
        {
            _context.WareHouses.Remove(wareHouse);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
