using Import_Export_Company.Data;
using Import_Export_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly AppDbContext _context;
        public PurchaseOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase_Orders>> GetAllAsync()
        {
            return await _context.PurchaseOrders
                .Include(p => p.PurchaseOrderDetails)
                .Include(p=>p.ImportDocuments)
                .ToListAsync();
        }
        
        public async Task<Purchase_Orders> GetByIdAsync(int id)
        {
            return await _context.PurchaseOrders
                .Include(p => p.PurchaseOrderDetails)
                .Include(p => p.ImportDocuments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Purchase_Orders> GetByPoNumberAsync(string poNumber)
        {
            return await _context.PurchaseOrders
                .FirstOrDefaultAsync(p => p.Po_Number == poNumber);
        }

        public async Task AddAsync(Purchase_Orders purchaseOrder)
        {
            await _context.PurchaseOrders.AddAsync(purchaseOrder);
        }

        public void Update(Purchase_Orders order)
        {
            _context.PurchaseOrders.Update(order);
        }

        public void Delete(Purchase_Orders order)
        {
            _context.PurchaseOrders.Remove(order);
        }
        public async Task AddImportDocumentAsync(Import_Documents doc)
        {
            await _context.ImportDocuments.AddAsync(doc);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
