using DTO.ReqDTO;
using DTO.ResDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ICartService
    {
        Task<bool> AddToCart(CartReqDTO cartReqDTO);
        Task<List<CartResDTO>> GetCartItems(int userId);
        Task<bool> UpdateCartItem(int cartId, int quantity);
        Task<bool> RemoveCartItem(int cartId);
    }
}
