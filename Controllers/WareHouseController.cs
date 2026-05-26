using Import_Export_Company.DTOs;
using Import_Export_Company.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Import_Export_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        private readonly IWareHouseService _wareHouseService;

        public WareHouseController(IWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wareHouses = await _wareHouseService.GetAllWareHousesAsync();
            return Ok(wareHouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var wareHouse = await _wareHouseService.GetWareHouseByIdAsync(id);
                return Ok(wareHouse);
            }
            catch (Exception ex) when (ex.Message == "Warehouse not found.")
            {
                return NotFound(new { message = "Không tìm thấy kho hàng trong hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWareHouse dto)
        {
            try
            {
                var createdWareHouse = await _wareHouseService.CreateWareHouseAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = createdWareHouse.Id }, createdWareHouse);
            }
            catch (Exception ex) when (ex.Message.Contains("Warehouse name already exists"))
            {
                return BadRequest(new { message = "Tên kho hàng này đã tồn tại, vui lòng nhập tên khác." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateWareHouse dto)
        {
            try
            {
                var updatedWareHouse = await _wareHouseService.UpdateWareHouseAsync(id, dto);
                return Ok(updatedWareHouse);
            }
            catch (Exception ex) when (ex.Message == "Warehouse not found.")
            {
                return NotFound(new { message = "Không tìm thấy kho hàng trong hệ thống." });
            }
            catch (Exception ex) when (ex.Message.Contains("Warehouse name already exists"))
            {
                return BadRequest(new { message = "Tên kho hàng này đã tồn tại, vui lòng nhập tên khác." });
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
                await _wareHouseService.DeleteWareHouseAsync(id);
                return Ok(new { message = "Kho hàng đã được xóa thành công." });
            }
            catch (Exception ex) when (ex.Message == "Warehouse not found.")
            {
                return NotFound(new { message = "Không tìm thấy kho hàng trong hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
