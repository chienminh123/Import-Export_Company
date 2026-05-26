using Import_Export_Company.Data;
using Import_Export_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customers> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
        public async Task<Customers> GetByCustomerNameAsync(string name)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Customer_name == name);
        }
        public async Task AddAsync(Customers customer)
        {
            await _context.Customers.AddAsync(customer);
        }
        public void UpdateAsync(Customers customer)
        {
            _context.Customers.Update(customer);
        }
        public void DeleteAsync(Customers customer)
        {
            _context.Customers.Remove(customer);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
