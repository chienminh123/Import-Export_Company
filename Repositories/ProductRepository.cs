using Import_Export_Company.Data;
using Import_Export_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Products> GetBySkuAsync(string sku)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Sku == sku);
        }

        public async Task AddAsync(Products product)
        {
            await _context.Products.AddAsync(product);
        }

        public void UpdateAsync(Products product)
        {
            _context.Products.Update(product);
        }

        public void DeleteAsync(Products product)
        {
            _context.Products.Remove(product);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
