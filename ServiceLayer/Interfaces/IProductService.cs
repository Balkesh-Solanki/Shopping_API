using DTO.ReqDTO;
using DTO.ResDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProduct(ProductReqDTO productReqDTO);
        Task<List<ProductResDTO>> GetAllProducts();
        Task<ProductResDTO> GetProductById(int id);
        Task<bool> UpdateProduct(int id, ProductReqDTO productReqDTO);
        Task<bool> DeleteProduct(int id);
    }
}
