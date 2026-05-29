using Import_Export_Company.DTOs.Request;
using Import_Export_Company.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Import_Export_Company.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Sales, Warehouse, Accountant")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (Exception ex) when (ex.Message == "Product not found.")
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm trong hệ thống." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Warehouse")]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO dto)
        {
            try
            {
                var createdProduct = await _productService.CreateProductAsync(dto);

                return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex) when (ex.Message.Contains("SKU already exists"))
            {
                return BadRequest(new { message = "Mã SKU này đã tồn tại, vui lòng nhập mã khác." }); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Warehouse")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateProductDTO dto)
        {
            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(id, dto);
                return Ok(updatedProduct); 
            }
            catch (Exception ex) when (ex.Message == "Product not found.")
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm để cập nhật." });
            }
            catch (Exception ex) when (ex.Message.Contains("SKU already exists"))
            {
                return BadRequest(new { message = "Mã SKU mới bị trùng với một sản phẩm khác." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Warehouse")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return Ok(new { message = "Xóa sản phẩm thành công." }); 
            }
            catch (Exception ex) when (ex.Message == "Product not found.")
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm để xóa." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}