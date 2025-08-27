using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.UserCart;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.UserCart
{
    public class AddUserCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserCartService _userCartService,
        IProductService _productService,
        ICartService _cartService)
        : HandlerBase<AddUserCartRequest, AddUserCartResponse>(_logger, _amazonContext)
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

            if (cart is null)
                return NotFound($"Cart with ID {Request.CartId} not found");

            var existingUserCart = await _userCartService.GetAll()
                .Where(x => x.CartId == Request.CartId && x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (existingUserCart is not null)
                return Conflict($"Product with ID {Request.ProductId} already exists in Cart ID {Request.CartId}");

            var userCart = new Data.Entities.UserCart()
            {
                ProductId = Request.ProductId,
                CartId = Request.CartId,
                CreatedBy = 101,
                CreatedOn = DateTime.UtcNow
            };

            await _userCartService.AddAsync(userCart);

            Response.UserCartId = userCart.UserCartId;
            return Success();
        }
    }
}
