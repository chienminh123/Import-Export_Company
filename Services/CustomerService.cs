using Import_Export_Company.DTOs;
using Import_Export_Company.Repositories;

namespace Import_Export_Company.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Customer_name = c.Customer_name,
                Phone = c.Phone,
                Email = c.Email,
                Delivery_address = c.Delivery_address
            });
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) throw new Exception("Customer not found.");
            return new CustomerDTO
            {
                Id = customer.Id,
                Customer_name = customer.Customer_name,
                Phone = customer.Phone,
                Email = customer.Email,
                Delivery_address = customer.Delivery_address
            };
        }

        public async Task<CustomerDTO> CreateCustomerAsync(CreateCustomerDTO customer)
        {
            var existingCustomer = await _customerRepository.GetByCustomerNameAsync(customer.Customer_name);
            if (existingCustomer != null)
            {
                throw new Exception("Customer name already exists.");
            }

            var newCustomer = new Models.Customers
            {
                Customer_name = customer.Customer_name,
                Phone = customer.Phone,
                Email = customer.Email,
                Delivery_address = customer.Delivery_address
            };
            await _customerRepository.AddAsync(newCustomer);
            await _customerRepository.SaveChangesAsync();

            var createdCustomer = await _customerRepository.GetByCustomerNameAsync(customer.Customer_name);
            return new CustomerDTO
            {
                Id = createdCustomer.Id,
                Customer_name = createdCustomer.Customer_name,
                Phone = createdCustomer.Phone,
                Email = createdCustomer.Email,
                Delivery_address = createdCustomer.Delivery_address
            };
        }

        public async Task<CustomerDTO> UpdateCustomerAsync(int id, CreateCustomerDTO customer)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new Exception("Customer not found.");
            }
            if (existingCustomer.Customer_name != customer.Customer_name)
            {
                var customerWithName = await _customerRepository.GetByCustomerNameAsync(customer.Customer_name);
                if (customerWithName != null) throw new Exception("Customer with the same name already exists.");
            }
            existingCustomer.Customer_name = customer.Customer_name;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Email = customer.Email;
            existingCustomer.Delivery_address = customer.Delivery_address;
            _customerRepository.UpdateAsync(existingCustomer);
            await _customerRepository.SaveChangesAsync();

            return new CustomerDTO
            {
                Id = existingCustomer.Id,
                Customer_name = existingCustomer.Customer_name,
                Phone = existingCustomer.Phone,
                Email = existingCustomer.Email,
                Delivery_address = existingCustomer.Delivery_address
            };
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(id);
            if (existingCustomer == null)
            {
                throw new Exception("Customer not found.");
            }
            _customerRepository.DeleteAsync(existingCustomer);
            await _customerRepository.SaveChangesAsync();
        }
    }
}
