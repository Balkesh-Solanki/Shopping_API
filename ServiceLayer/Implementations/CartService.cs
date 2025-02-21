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
    public class CartService : ICartService
    {
        private readonly CartBLL _cartBLL;

        public CartService(CartBLL cartBLL)
        {
            _cartBLL = cartBLL;
        }

        public async Task<bool> AddToCart(CartReqDTO cartReqDTO)
        {
            return await _cartBLL.AddToCart(cartReqDTO);
        }

        public async Task<List<CartResDTO>> GetCartItems(int userId)
        {
            return await _cartBLL.GetCartItems(userId);
        }

        public async Task<bool> UpdateCartItem(int cartId, int quantity)
        {
            return await _cartBLL.UpdateCartItem(cartId, quantity);
        }

        public async Task<bool> RemoveCartItem(int cartId)
        {
            return await _cartBLL.RemoveCartItem(cartId);
        }
    }
}
