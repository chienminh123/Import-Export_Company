using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;
using Import_Export_Company.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Import_Export_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IPurchaseOrderService _service;

        public PurchaseOrdersController(IPurchaseOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Warehouse, Accountant")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _service.GetOrderByIdAsync(id);
                return Ok(order);
            }
            catch (Exception ex) when (ex.Message == "Order not found.")
            {
                return NotFound(new { message = "Không tìm thấy đơn mua hàng trong hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseOrderDTO dto)
        {
            try
            {
                var result = await _service.CreateOrderAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex) when (ex.Message == "PO_NUMBER_EXISTS")
            {
                return BadRequest(new { message = "Mã đơn hàng PO này đã tồn tại trên hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/shipping")]
        public async Task<IActionResult> UpdateToShipping(int id, [FromBody] ImportDocumentDTO docDto)
        {
            try
            {
                var result = await _service.UpdateToShippingAsync(id, docDto);
                return Ok(result);
            }
            catch (Exception ex) when (ex.Message == "Order not found.")
            {
                return NotFound(new { message = "Không tìm thấy đơn mua hàng tương ứng." });
            }
            catch (Exception ex) when (ex.Message == "INVALID_STATUS")
            {
                return BadRequest(new { message = "Trạng thái đơn hàng hiện tại không hợp lệ để cập nhật chứng từ." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteOrderAsync(id);
                return Ok(new { message = "Xóa đơn mua hàng thành công." });
            }
            catch (Exception ex) when (ex.Message == "Order not found.")
            {
                return NotFound(new { message = "Không tìm thấy đơn mua hàng." });
            }
            catch (Exception ex) when (ex.Message == "INVALID_STATUS_FOR_DELETE")
            {
                return BadRequest(new { message = "Chỉ được phép xóa đơn hàng khi đang ở trạng thái chờ xử lý (PENDING)." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                var result = await _service.CancelOrderAsync(id);
                return Ok(result);
            }
            catch (Exception ex) when (ex.Message == "Order not found.")
            {
                return NotFound(new { message = "Không tìm thấy đơn mua hàng." });
            }
            catch (Exception ex) when (ex.Message == "INVALID_STATUS_FOR_CANCEL")
            {
                return BadRequest(new { message = "Không thể hủy đơn hàng đã hoàn thành nhập kho hoặc đã bị hủy trước đó." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/confirm-import")]
        [Authorize(Roles = "Admin, Warehouse")]
        public async Task<IActionResult> ConfirmImport(int id, [FromQuery] int warehouseId)
        {
            try
            {
                var result = await _service.ConfirmImportAsync(id, warehouseId);
                return Ok(result);
            }
            catch (Exception ex) when (ex.Message == "Order not found.")
            {
                return NotFound(new { message = "Không tìm thấy đơn mua hàng." });
            }
            catch (Exception ex) when (ex.Message == "INVALID_STATUS")
            {
                return BadRequest(new { message = "Đơn hàng phải ở trạng thái SHIPPING mới được phép xác nhận nhập kho vật lý." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
