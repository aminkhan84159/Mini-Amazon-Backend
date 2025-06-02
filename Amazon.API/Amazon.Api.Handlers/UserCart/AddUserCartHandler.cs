using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.UserCart;
using Amazon.Api.Services.Interfaces;
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
            var product = await _productService.GetByIdAsync(Request.ProductId);

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} not found");

            var cart = await _cartService.GetByIdAsync(Request.CartId);

            if (cart is null)
                return NotFound($"Cart with ID {Request.CartId} not found");

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
