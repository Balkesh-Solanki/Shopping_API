using DTO.ReqDTO;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add-to-cart")]
        public async Task<IActionResult> AddToCart([FromBody] CartReqDTO cartReqDTO)
        {
            var result = await _cartService.AddToCart(cartReqDTO);
            if (!result) return BadRequest("Failed to add item to cart");
            return Ok("Item added to cart successfully");
        }

        [HttpGet("get-cart-items/{userId}")]
        public async Task<IActionResult> GetCartItems(int userId)
        {
            var result = await _cartService.GetCartItems(userId);
            return Ok(result);
        }

        [HttpPut("update-cart-item/{cartId}/{quantity}")]
        public async Task<IActionResult> UpdateCartItem(int cartId, int quantity)
        {
            var result = await _cartService.UpdateCartItem(cartId, quantity);
            if (!result) return NotFound("Cart item not found");
            return Ok("Cart item updated successfully");
        }

        [HttpDelete("remove-cart-item/{cartId}")]
        public async Task<IActionResult> RemoveCartItem(int cartId)
        {
            var result = await _cartService.RemoveCartItem(cartId);
            if (!result) return NotFound("Cart item not found");
            return Ok("Cart item removed successfully");
        }
    }
}
