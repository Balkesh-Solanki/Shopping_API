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
    public class ProductBLL 
    {
        private readonly AppDbContext _context;

        public ProductBLL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProduct(ProductReqDTO productReqDTO)
        {
            var product = new Product
            {
                Name = productReqDTO.Name,
                //Description = productReqDTO.Description,
                Price = productReqDTO.Price,
                SubCategoryId = productReqDTO.SubCategoryId,
                ImageUrl = productReqDTO.ImageUrl
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductResDTO>> GetAllProducts()
        {
            return await _context.Products
                .Select(p => new ProductResDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    //Description = p.Description,
                    Price = p.Price,
                    SubCategoryId = p.SubCategoryId,
                    SubCategoryName = p.SubCategory.Name,
                    ImageUrl = p.ImageUrl
                }).ToListAsync();
        }

        public async Task<ProductResDTO> GetProductById(int id)
        {
            var product = await _context.Products
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return null;

            return new ProductResDTO
            {
                Id = product.Id,
                Name = product.Name,
                //Description = product.Description,
                Price = product.Price,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategory.Name,
                ImageUrl = product.ImageUrl
            };
        }

        public async Task<bool> UpdateProduct(int id, ProductReqDTO productReqDTO)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            product.Name = productReqDTO.Name;
            //product.Description = productReqDTO.Description;
            product.Price = productReqDTO.Price;
            product.SubCategoryId = productReqDTO.SubCategoryId;
            product.ImageUrl = productReqDTO.ImageUrl;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
