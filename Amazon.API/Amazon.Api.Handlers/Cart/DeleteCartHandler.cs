using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Cart;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var cart = await _cartService.GetAll()
                .Where(x => x.CartId == Request.CartId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (cart is null)
                return NotFound($"Cart with ID {Request.CartId} not found");

            cart.IsActive = false;
            cart.UpdatedBy = 101;
            cart.UpdatedOn = DateTime.UtcNow;

            await _cartService.UpdateAsync(cart);

            Response.CartId = cart.CartId;
            return Success();
        }
    }
}
