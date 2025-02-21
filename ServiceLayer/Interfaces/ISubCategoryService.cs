using DTO.ReqDTO;
using DTO.ResDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ISubCategoryService
    {
        Task<bool> AddSubCategory(SubCategoryReqDTO subCategoryReqDTO);
        Task<List<SubCategoryResDTO>> GetAllSubCategories();
        Task<SubCategoryResDTO> GetSubCategoryById(int id);
        Task<bool> UpdateSubCategory(int id, SubCategoryReqDTO subCategoryReqDTO);
        Task<bool> DeleteSubCategory(int id);
    }
}
