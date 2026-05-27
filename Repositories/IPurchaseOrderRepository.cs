using Import_Export_Company.Models;

namespace Import_Export_Company.Repositories
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<Purchase_Orders>> GetAllAsync();
        Task<Purchase_Orders> GetByIdAsync(int id);
        Task<Purchase_Orders> GetByPoNumberAsync(string poNumber);
        Task AddAsync(Purchase_Orders order);
        void Update(Purchase_Orders order);
        void Delete(Purchase_Orders order);
        Task AddImportDocumentAsync(Import_Documents doc);
        Task SaveChangesAsync();
    }
}
