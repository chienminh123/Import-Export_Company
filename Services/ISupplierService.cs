using Import_Export_Company.DTOs;

namespace Import_Export_Company.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDTO>> GetAllSuppliersAsync();
        Task<SupplierDTO> GetSupplierByIdAsync(int id);
        Task<SupplierDTO> CreateSupplierAsync(CreateSupplierDTO supplier);
        Task<SupplierDTO> UpdateSupplierAsync(int id, CreateSupplierDTO supplier);
        Task DeleteSupplierAsync(int id);
    }
}
