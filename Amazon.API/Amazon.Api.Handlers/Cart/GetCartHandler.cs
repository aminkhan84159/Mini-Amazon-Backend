using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Cart;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Cart
{
    public class GetCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        ICartService _cartService)
        : HandlerBase<GetCartRequest, GetCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var cart = await _cartService.GetAll()
                .Where(x => x.CartId == Request.CartId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (cart is null)
                return NotFound($"Cart with ID {Request.CartId} not found");

            Response.CartDetails = new CartDto()
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                IsActive = cart.IsActive,
                CreatedBy = cart.CreatedBy,
                CreatedOn = cart.CreatedOn,
                UpdatedBy = cart.UpdatedBy,
                UpdatedOn = cart.UpdatedOn
            };

            return Success();
        }
    }
}
