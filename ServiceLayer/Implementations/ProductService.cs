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
    public class ProductService : IProductService
    {
        private readonly ProductBLL _productBLL;

        public ProductService(ProductBLL productBLL)
        {
            _productBLL = productBLL;
        }

        public async Task<bool> AddProduct(ProductReqDTO productReqDTO)
        {
            return await _productBLL.AddProduct(productReqDTO);
        }

        public async Task<List<ProductResDTO>> GetAllProducts()
        {
            return await _productBLL.GetAllProducts();
        }

        public async Task<ProductResDTO> GetProductById(int id)
        {
            return await _productBLL.GetProductById(id);
        }

        public async Task<bool> UpdateProduct(int id, ProductReqDTO productReqDTO)
        {
            return await _productBLL.UpdateProduct(id, productReqDTO);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productBLL.DeleteProduct(id);
        }
    }
}
