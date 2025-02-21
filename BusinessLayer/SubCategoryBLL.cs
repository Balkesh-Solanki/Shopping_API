using DataLayer.DbScript;
using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SubCategoryBLL 
    {
        private readonly AppDbContext _context;

        public SubCategoryBLL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddSubCategory(SubCategoryReqDTO subCategoryReqDTO)
        {
            var subCategory = new Subcategory
            {
                Name = subCategoryReqDTO.Name,
                CategoryId = subCategoryReqDTO.CategoryId
            };
            _context.Subcategories.Add(subCategory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<SubCategoryResDTO>> GetAllSubCategories()
        {
            return await _context.Subcategories
                .Include(sc => sc.Category)
                .Select(sc => new SubCategoryResDTO
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CategoryId = sc.CategoryId,
                    CategoryName = sc.Category.Name
                }).ToListAsync();
        }

        public async Task<SubCategoryResDTO> GetSubCategoryById(int id)
        {
            var subCategory = await _context.Subcategories
                .Include(sc => sc.Category)
                .FirstOrDefaultAsync(sc => sc.Id == id);

            if (subCategory == null) return null;

            return new SubCategoryResDTO
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId,
                CategoryName = subCategory.Category.Name
            };
        }

        public async Task<bool> UpdateSubCategory(int id, SubCategoryReqDTO subCategoryReqDTO)
        {
            var subCategory = await _context.Subcategories.FindAsync(id);
            if (subCategory == null) return false;

            subCategory.Name = subCategoryReqDTO.Name;
            subCategory.CategoryId = subCategoryReqDTO.CategoryId;

            _context.Subcategories.Update(subCategory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSubCategory(int id)
        {
            var subCategory = await _context.Subcategories.FindAsync(id);
            if (subCategory == null) return false;

            _context.Subcategories.Remove(subCategory);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
