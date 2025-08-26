using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.UserCart;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.UserCart
{
    public class UpdateUserCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserCartService _userCartService,
        IProductService _productService,
        ICartService _cartService)
        : HandlerBase<UpdateUserCartRequest, UpdateUserCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var userCart = await _userCartService.GetAll()
                .Where(x => x.UserCartId == Request.UserCartId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (userCart is null)
                return NotFound($"User cart with ID {Request.UserCartId} not found");

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

            userCart.ProductId = Request.ProductId;
            userCart.CartId = Request.CartId;
            userCart.UpdatedBy = 101;
            userCart.UpdatedOn = DateTime.UtcNow;

            await _userCartService.UpdateAsync(userCart);

            var usercartDetail = new UserCartDto()
            {
                UserCartId = userCart.UserCartId,
                ProductId = userCart.ProductId,
                CartId = userCart.CartId,
                IsActive = userCart.IsActive,
                CreatedBy = userCart.CreatedBy,
                CreatedOn = userCart.CreatedOn,
                UpdatedBy = userCart.UpdatedBy,
                UpdatedOn = userCart.UpdatedOn
            };

            Response.UserCartDetails = usercartDetail;
            return Success();
        }
    }
}
