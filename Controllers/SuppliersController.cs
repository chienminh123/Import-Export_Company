using Import_Export_Company.DTOs.Request;
using Import_Export_Company.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Import_Export_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            try
            {
                var supplier = await _supplierService.GetSupplierByIdAsync(id);
                return Ok(supplier);

            }
            catch (Exception ex) when (ex.Message == "Supplier not found.")
            {
                return NotFound(new { message = "Không tìm thấy nhà cung cấp trong hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierDTO dto)
        {
            try
            {
                var createdSupplier = await _supplierService.CreateSupplierAsync(dto);
                return CreatedAtAction(nameof(GetSupplierById), new { id = createdSupplier.Id }, createdSupplier);
            }
            catch (Exception ex) when (ex.Message.Contains("Supplier company name already exists"))
            {
                return BadRequest(new { message = "Tên công ty nhà cung cấp đã tồn tại, vui lòng nhập tên khác." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] CreateSupplierDTO dto)
        {
            try
            {
                var updatedSupplier = await _supplierService.UpdateSupplierAsync(id, dto);
                return Ok(updatedSupplier);
            }
            catch (Exception ex) when (ex.Message == "Supplier not found.")
            {
                return NotFound(new { message = "Không tìm thấy nhà cung cấp trong hệ thống." });
            }
            catch (Exception ex) when (ex.Message.Contains("Supplier with the same company name already exists"))
            {
                return BadRequest(new { message = "Tên công ty nhà cung cấp đã tồn tại, vui lòng nhập tên khác." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            try
            {
                await _supplierService.DeleteSupplierAsync(id);
                return Ok(new { message = "Nhà cung cấp đã được xóa thành công." });
            }
            catch (Exception ex) when (ex.Message == "Supplier not found.")
            {
                return NotFound(new { message = "Không tìm thấy nhà cung cấp trong hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
