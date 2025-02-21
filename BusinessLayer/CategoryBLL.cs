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
    public class CategoryBLL
    {
        private readonly AppDbContext _context;

        public CategoryBLL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryResDTO>> GetAllCategories()
        {
            return await _context.Categories
                .Select(c => new CategoryResDTO { Id = c.Id, Name = c.Name })
                .ToListAsync();
        }

        public async Task<CategoryResDTO> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return null;

            return new CategoryResDTO { Id = category.Id, Name = category.Name };
        }

        public async Task<CategoryResDTO> AddCategory(CategoryReqDTO categoryReq)
        {
            var newCategory = new Category 
            { 
                Name = categoryReq.Name 
            };
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return new CategoryResDTO { Id = newCategory.Id, Name = newCategory.Name };
        }

        public async Task<bool> UpdateCategory(int id, CategoryReqDTO categoryReq)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
                return false;

            existingCategory.Name = categoryReq.Name;
            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
