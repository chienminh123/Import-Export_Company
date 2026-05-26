using Import_Export_Company.Data;
using Import_Export_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;
        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Suppliers>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Suppliers> GetByIdAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task<Suppliers> GetByCompanyNameAsync(string name)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(s => s.Company_name == name);
        }

        public async Task AddAsync(Suppliers supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
        }

        public void UpdateAsync(Suppliers supplier)
        {
            _context.Suppliers.Update(supplier);
        }

        public void DeleteAsync(Suppliers supplier)
        {
            _context.Suppliers.Remove(supplier);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
