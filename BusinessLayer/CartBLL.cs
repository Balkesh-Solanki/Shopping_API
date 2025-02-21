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
    public class CartBLL
    {
        private readonly AppDbContext _context;

        public CartBLL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToCart(CartReqDTO cartReqDTO)
        {
            var existingCartItem = await _context.Carts
                  .FirstOrDefaultAsync(c => c.ProductId == cartReqDTO.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cartReqDTO.Quantity;
            }
            else
            {
                var cartItem = new Cart
                {
                    ProductId = cartReqDTO.ProductId,
                    Quantity = cartReqDTO.Quantity
                };

                _context.Carts.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CartResDTO>> GetCartItems(int productId)
        {
            return await _context.Carts
                 .Where(c => c.ProductId == productId)
                .Select(c => new CartResDTO
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    ProductName = c.Product.Name,
                    Quantity = c.Quantity
                }).ToListAsync();
        }

        public async Task<bool> UpdateCartItem(int cartId, int quantity)
        {
            var cartItem = await _context.Carts.FindAsync(cartId);
            if (cartItem == null) return false;

            cartItem.Quantity = quantity;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCartItem(int cartId)
        {
            var cartItem = await _context.Carts.FindAsync(cartId);
            if (cartItem == null) return false;

            _context.Carts.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
