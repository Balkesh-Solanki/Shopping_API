using DTO.ReqDTO;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound("Category not found.");

            return Ok(category);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryReqDTO categoryReq)
        {
            var category = await _categoryService.AddCategory(categoryReq);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryReqDTO categoryReq)
        {
            var result = await _categoryService.UpdateCategory(id, categoryReq);
            if (!result)
                return NotFound("Category not found.");

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result)
                return NotFound("Category not found.");

            return NoContent();
        }
    }
}
