using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;

namespace Import_Export_Company.Services
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrderDTO>> GetAllOrdersAsync();
        Task<PurchaseOrderDTO> GetOrderByIdAsync(int id);
        Task<PurchaseOrderDTO> CreateOrderAsync(CreatePurchaseOrderDTO dto);
        Task DeleteOrderAsync(int id);
        Task<PurchaseOrderDTO> CancelOrderAsync(int id);
        Task<PurchaseOrderDTO> UpdateToShippingAsync(int id, ImportDocumentDTO docDto);
        Task<PurchaseOrderDTO> ConfirmImportAsync(int id, int warehouseId);
    }
}
