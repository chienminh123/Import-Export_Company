using Import_Export_Company.DTOs.Request;
using Import_Export_Company.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Import_Export_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Sales, Accountant")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Sales, Accountant")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                return Ok(customer);

            }
            catch (Exception ex) when (ex.Message == "Customer not found.")
            {
                return NotFound(new { message = "Không tìm thấy khách hàng trong hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Sales")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO dto)
        {
            try
            {
                var createdCustomer = await _customerService.CreateCustomerAsync(dto);
                return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
            }
            catch (Exception ex) when (ex.Message.Contains("Customer name already exists"))
            {
                return BadRequest(new { message = "Tên khách hàng đã tồn tại, vui lòng nhập tên khác." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Sales")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CreateCustomerDTO dto)
        {
            try
            {
                var updatedCustomer = await _customerService.UpdateCustomerAsync(id, dto);
                return Ok(updatedCustomer);
            }
            catch (Exception ex) when (ex.Message == "Customer not found.")
            {
                return NotFound(new { message = "Không tìm thấy khách hàng trong hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return Ok(new { message = "Khách hàng đã được xóa thành công." });
            }
            catch (Exception ex) when (ex.Message == "Customer not found.")
            {
                return NotFound(new { message = "Không tìm thấy khách hàng trong hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
