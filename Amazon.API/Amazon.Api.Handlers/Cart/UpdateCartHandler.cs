using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Cart;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.Cart
{
    public class UpdateCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        ICartService _cartService)
        : HandlerBase<UpdateCartRequest, UpdateCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var cart = await _cartService.GetByIdAsync(Request.CartId);

            if (cart is null)
                return NotFound($"Cart with ID {Request.CartId} not found");

            cart.UserId = Request.UserId;
            cart.UpdatedBy = Request.UserId;
            cart.UpdatedOn = DateTime.UtcNow;

            await _cartService.UpdateAsync(cart);

            var cartDetails = new CartDto()
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                IsActive = cart.IsActive,
                CreatedBy = cart.CreatedBy,
                CreatedOn = cart.CreatedOn,
                UpdatedBy = cart.UpdatedBy,
                UpdatedOn = cart.UpdatedOn
            };

            Response.CartDetails = cartDetails;
            return Success();
        }
    }
}
