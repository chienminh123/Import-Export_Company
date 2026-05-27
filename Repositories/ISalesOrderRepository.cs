using Import_Export_Company.Models;

namespace Import_Export_Company.Repositories
{
    public interface ISalesOrderRepository
    {
        Task<IEnumerable<Sales_Orders>> GetAllAsync();
        Task<Sales_Orders> GetByIdAsync(int id);
        Task<Sales_Orders> GetBySoNumberAsync(string soNumber);
        Task AddAsync(Sales_Orders order);
        void Update(Sales_Orders order);
        void Delete(Sales_Orders order);
        Task SaveChangesAsync();
    }
}
