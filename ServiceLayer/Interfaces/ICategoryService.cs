using DTO.ReqDTO;
using DTO.ResDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResDTO>> GetAllCategories();
        Task<CategoryResDTO> GetCategoryById(int id);
        Task<CategoryResDTO> AddCategory(CategoryReqDTO categoryReq);
        Task<bool> UpdateCategory(int id, CategoryReqDTO categoryReq);
        Task<bool> DeleteCategory(int id);
    }
}
