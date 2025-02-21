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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly SubCategoryBLL _subCategoryBLL;

        public SubCategoryService(SubCategoryBLL subCategoryBLL)
        {
            _subCategoryBLL = subCategoryBLL;
        }

        public async Task<bool> AddSubCategory(SubCategoryReqDTO subCategoryReqDTO)
        {
            return await _subCategoryBLL.AddSubCategory(subCategoryReqDTO);
        }

        public async Task<List<SubCategoryResDTO>> GetAllSubCategories()
        {
            return await _subCategoryBLL.GetAllSubCategories();
        }

        public async Task<SubCategoryResDTO> GetSubCategoryById(int id)
        {
            return await _subCategoryBLL.GetSubCategoryById(id);
        }

        public async Task<bool> UpdateSubCategory(int id, SubCategoryReqDTO subCategoryReqDTO)
        {
            return await _subCategoryBLL.UpdateSubCategory(id, subCategoryReqDTO);
        }

        public async Task<bool> DeleteSubCategory(int id)
        {
            return await _subCategoryBLL.DeleteSubCategory(id);
        }
    }
}
