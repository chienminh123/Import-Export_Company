using Import_Export_Company.Data;
using Import_Export_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly AppDbContext _context;

        public SalesOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sales_Orders>> GetAllAsync()
        {
            return await _context.SalesOrders
                .Include(s => s.SalesOrderDetails)
                .ToListAsync();
        }

        public async Task<Sales_Orders> GetByIdAsync(int id)
        {
            return await _context.SalesOrders
                .Include(s => s.SalesOrderDetails)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Sales_Orders> GetBySoNumberAsync(string soNumber)
        {
            return await _context.SalesOrders
                .FirstOrDefaultAsync(s => s.So_Number == soNumber);
        }

        public async Task AddAsync(Sales_Orders order)
        {
            await _context.SalesOrders.AddAsync(order);
        }

        public void Update(Sales_Orders order)
        {
            _context.SalesOrders.Update(order);
        }

        public void Delete(Sales_Orders order)
        {
            _context.SalesOrders.Remove(order);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
