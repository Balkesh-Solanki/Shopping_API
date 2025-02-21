using DTO.ReqDTO;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSubCategory([FromBody] SubCategoryReqDTO subCategoryReqDTO)
        {
            var result = await _subCategoryService.AddSubCategory(subCategoryReqDTO);
            if (!result) return BadRequest("Failed to add subcategory.");
            return Ok("Subcategory added successfully.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var result = await _subCategoryService.GetAllSubCategories();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategoryById(int id)
        {
            var result = await _subCategoryService.GetSubCategoryById(id);
            if (result == null) return NotFound("Subcategory not found.");
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSubCategory(int id, [FromBody] SubCategoryReqDTO subCategoryReqDTO)
        {
            var result = await _subCategoryService.UpdateSubCategory(id, subCategoryReqDTO);
            if (!result) return BadRequest("Failed to update subcategory.");
            return Ok("Subcategory updated successfully.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var result = await _subCategoryService.DeleteSubCategory(id);
            if (!result) return BadRequest("Failed to delete subcategory.");
            return Ok("Subcategory deleted successfully.");
        }
    }
}
