using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;
using Import_Export_Company.Models;
using Import_Export_Company.Repositories;

namespace Import_Export_Company.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<SupplierDTO>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync();

            return suppliers.Select(s => new SupplierDTO
            {
                Id = s.Id,
                Company_name = s.Company_name,
                Contact_name = s.Contact_name,
                Address = s.Address,
                Country = s.Country,
                Phone = s.Phone,
                Email = s.Email
            });
        }

        public async Task<SupplierDTO> GetSupplierByIdAsync(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier == null) throw new Exception("Supplier not found.");
            return new SupplierDTO
            {
                Id = supplier.Id,
                Company_name = supplier.Company_name,
                Contact_name = supplier.Contact_name,
                Address = supplier.Address,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Email = supplier.Email
            };
        }

        public async Task<SupplierDTO> CreateSupplierAsync(CreateSupplierDTO supplier)
        {
            var existingSupplier = await _supplierRepository.GetByCompanyNameAsync(supplier.Company_name);
            if (existingSupplier != null)
            {
                throw new Exception("Supplier company name already exists.");
            }
            var newSupplier = new Suppliers
            {
                Company_name = supplier.Company_name,
                Contact_name = supplier.Contact_name,
                Address = supplier.Address,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Email = supplier.Email
            };

            await _supplierRepository.AddAsync(newSupplier);
            await _supplierRepository.SaveChangesAsync();

            var createdSupplier = await _supplierRepository.GetByCompanyNameAsync(supplier.Company_name);
            return new SupplierDTO
            {
                Id = createdSupplier.Id,
                Company_name = createdSupplier.Company_name,
                Contact_name = createdSupplier.Contact_name,
                Address = createdSupplier.Address,
                Country = createdSupplier.Country,
                Phone = createdSupplier.Phone,
                Email = createdSupplier.Email
            };
        } 

        public async Task<SupplierDTO> UpdateSupplierAsync(int id, CreateSupplierDTO supplier)
        {
            var existingSupplier = await _supplierRepository.GetByIdAsync(id);
            if (existingSupplier == null) throw new Exception("Supplier not found.");

            if (existingSupplier.Company_name != supplier.Company_name)
            {
                var supplierWithName = await _supplierRepository.GetByCompanyNameAsync(supplier.Company_name);
                if (supplierWithName != null) throw new Exception("Supplier with the same company name already exists.");
            }
            existingSupplier.Company_name = supplier.Company_name;
            existingSupplier.Contact_name = supplier.Contact_name;
            existingSupplier.Address = supplier.Address;
            existingSupplier.Country = supplier.Country;
            existingSupplier.Phone = supplier.Phone;
            existingSupplier.Email = supplier.Email;

            _supplierRepository.UpdateAsync(existingSupplier);
            await _supplierRepository.SaveChangesAsync();

            return new SupplierDTO
            {
                Id = existingSupplier.Id,
                Company_name = existingSupplier.Company_name,
                Contact_name = existingSupplier.Contact_name,
                Address = existingSupplier.Address,
                Country = existingSupplier.Country,
                Phone = existingSupplier.Phone,
                Email = existingSupplier.Email
            };
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier == null) throw new Exception("Supplier not found.");

            _supplierRepository.DeleteAsync(supplier);
            await _supplierRepository.SaveChangesAsync();
        }
    }
}
