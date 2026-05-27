using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;

namespace Import_Export_Company.Services
{
    public interface ISalesOrderService
    {
        Task<IEnumerable<SalesOrderDTO>> GetAllOrdersAsync();
        Task<SalesOrderDTO> GetOrderByIdAsync(int id);
        Task<SalesOrderDTO> CreateOrderAsync(CreateSalesOrderDTO dto);
        Task<SalesOrderDTO> ConfirmExportAsync(int id);
        Task<SalesOrderDTO> CancelOrderAsync(int id);
    }
}
