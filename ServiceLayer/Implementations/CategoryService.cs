using BusinessLayer;
using DTO.ReqDTO;
using DTO.ResDTO;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryBLL _categoryBLL;

        public CategoryService(CategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }

        public async Task<IEnumerable<CategoryResDTO>> GetAllCategories()
        {
            return await _categoryBLL.GetAllCategories();
        }

        public async Task<CategoryResDTO> GetCategoryById(int id)
        {
            return await _categoryBLL.GetCategoryById(id);
        }

        public async Task<CategoryResDTO> AddCategory(CategoryReqDTO categoryReq)
        {
            return await _categoryBLL.AddCategory(categoryReq);
        }

        public async Task<bool> UpdateCategory(int id, CategoryReqDTO categoryReq)
        {
            return await _categoryBLL.UpdateCategory(id, categoryReq);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _categoryBLL.DeleteCategory(id);
        }
    }
}
