using DTO.ReqDTO;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] ProductReqDTO productReqDTO)
        {
            var result = await _productService.AddProduct(productReqDTO);
            if (!result) return BadRequest("Failed to add product");
            return Ok("Product added successfully");
        }

        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("get-product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productService.GetProductById(id);
            if (result == null) return NotFound("Product not found");
            return Ok(result);
        }

        [HttpPut("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductReqDTO productReqDTO)
        {
            var result = await _productService.UpdateProduct(id, productReqDTO);
            if (!result) return NotFound("Product not found");
            return Ok("Product updated successfully");
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (!result) return NotFound("Product not found");
            return Ok("Product deleted successfully");
        }
    }
}
