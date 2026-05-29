using Import_Export_Company.DTOs.Request;
using Import_Export_Company.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Import_Export_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrdersController : ControllerBase
    {
        private readonly ISalesOrderService _soService;

        public SalesOrdersController(ISalesOrderService soService)
        {
            _soService = soService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Sales, Warehouse, Accountant")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _soService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _soService.GetOrderByIdAsync(id);
                return Ok(order);
            }
            catch (Exception ex) when (ex.Message == "Order not found.")
            {
                return NotFound(new { message = "Không tìm thấy đơn bán hàng." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Sales")]
        public async Task<IActionResult> Create([FromBody] CreateSalesOrderDTO dto)
        {
            try
            {
                var result = await _soService.CreateOrderAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex) when (ex.Message == "SO_NUMBER_EXISTS")
            {
                return BadRequest(new { message = "Mã đơn hàng SO này đã tồn tại." });
            }
            catch (Exception ex) when (ex.Message.StartsWith("STOCK_NOT_FOUND"))
            {
                return BadRequest(new { message = "Sản phẩm không tồn tại trong kho chỉ định." });
            }
            catch (Exception ex) when (ex.Message.StartsWith("NOT_ENOUGH_STOCK"))
            {
                return BadRequest(new { message = "Tồn kho khả dụng không đủ để đáp ứng số lượng đặt hàng." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/confirm-export")]
        [Authorize(Roles = "Admin, Warehouse")]
        public async Task<IActionResult> ConfirmExport(int id)
        {
            try
            {
                var result = await _soService.ConfirmExportAsync(id);
                return Ok(result);
            }
            catch (Exception ex) when (ex.Message == "Order not found.")
            {
                return NotFound(new { message = "Không tìm thấy đơn bán hàng." });
            }
            catch (Exception ex) when (ex.Message == "INVALID_STATUS")
            {
                return BadRequest(new { message = "Đơn hàng phải ở trạng thái PENDING mới được phép xuất kho." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/cancel")]
        [Authorize(Roles = "Admin, Sales")]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                var result = await _soService.CancelOrderAsync(id);
                return Ok(result);
            }
            catch (Exception ex) when (ex.Message == "Order not found.")
            {
                return NotFound(new { message = "Không tìm thấy đơn bán hàng." });
            }
            catch (Exception ex) when (ex.Message == "INVALID_STATUS_FOR_CANCEL")
            {
                return BadRequest(new { message = "Chỉ được hủy đơn hàng ở trạng thái PENDING." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
