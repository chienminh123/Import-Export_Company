using Import_Export_Company.DTOs;

namespace Import_Export_Company.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);

        Task<CustomerDTO> CreateCustomerAsync(CreateCustomerDTO customer);
        Task<CustomerDTO> UpdateCustomerAsync(int id, CreateCustomerDTO customer);
        Task DeleteCustomerAsync(int id);
    }
}
