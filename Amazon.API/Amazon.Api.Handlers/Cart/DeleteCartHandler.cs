using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Cart;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.Cart
{
    public class DeleteCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        ICartService _cartService)
        : HandlerBase<DeleteCartRequest, DeleteCartResponse>(_logger, _amazonContext)
    {
        protected override async Task <bool> HandleCoreAsync()
        {
            var cart = await _cartService.GetByIdAsync(Request.CartId);

            if (cart is null)
                return NotFound($"Cart with ID {Request.CartId} not found");

            await _cartService.DeleteAsync(cart);

            Response.CartId = cart.CartId;
            return Success();
        }
    }
}
