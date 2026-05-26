using Import_Export_Company.DTOs;
using Import_Export_Company.Models;

namespace Import_Export_Company.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<ProductDTO> CreateProductAsync(CreateProductDTO product);
        Task<ProductDTO> UpdateProductAsync(int id, CreateProductDTO product);
        Task DeleteProductAsync(int id);
    }
}
