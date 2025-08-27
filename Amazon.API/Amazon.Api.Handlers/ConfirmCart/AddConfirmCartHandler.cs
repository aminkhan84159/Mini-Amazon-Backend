using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ConfirmCart;
using Amazon.Api.Services.Interfaces;
using Amazon.Api.Services.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ConfirmCart
{
    public class AddConfirmCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IConfirmCartService _confirmCartService,
        ICartService _cartService,
        IProductService _productService)
        : HandlerBase<AddConfirmCartRequest, AddConfirmCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetAll()
                .Where(x => x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} not found");

            var cart = await _cartService.GetAll()
                .Where(x => x.CartId == Request.CartId && x.IsActive == true)
                .FirstOrDefaultAsync();

            var existingConfirmCart = await _confirmCartService.GetAll()
                .Where(x => x.CartId == Request.CartId && x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (existingConfirmCart is not null)
                return Conflict($"Product with ID {Request.ProductId} is already confirmed in Cart ID {Request.CartId}");

            if (cart is null)
                return NotFound($"Cart with ID {Request.CartId} not found");

            var confirmCart = new Data.Entities.ConfirmCart()
            {
                ProductId = Request.ProductId,
                CartId = Request.CartId,
                CreatedBy = 101,
                CreatedOn = DateTime.UtcNow
            };

            await _confirmCartService.AddAsync(confirmCart);

            Response.ConfirmCartId = confirmCart.ConfirmCartId;
            return Success();
        }
    }
}
