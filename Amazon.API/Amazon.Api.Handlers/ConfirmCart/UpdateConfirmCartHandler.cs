using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.ConfirmCart;
using Amazon.Api.Services.Interfaces;
using Amazon.Api.Services.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ConfirmCart
{
    public class UpdateConfirmCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IConfirmCartService _confirmCartService,
        ICartService _cartService,
        IProductService _productService)
        : HandlerBase<UpdateConfirmCartRequest, UpdateConfirmCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var confirmCart = await _confirmCartService.GetAll()
                .Where(x => x.ConfirmCartId == Request.ConfirmCartId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (confirmCart is null)
                return NotFound($"confirm cart with ID {Request.ConfirmCartId} not found");

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

            confirmCart.ProductId = Request.ProductId;
            confirmCart.CartId = Request.CartId;
            confirmCart.UpdatedBy = 101;
            confirmCart.UpdatedOn = DateTime.UtcNow;

            await _confirmCartService.UpdateAsync(confirmCart);

            var confirmcartDetail = new ConfirmCartDto()
            {
                ConfirmCartId = confirmCart.ConfirmCartId,
                ProductId = confirmCart.ProductId,
                CartId = confirmCart.CartId,
                IsActive = confirmCart.IsActive,
                CreatedBy = confirmCart.CreatedBy,
                CreatedOn = confirmCart.CreatedOn,
                UpdatedBy = confirmCart.UpdatedBy,
                UpdatedOn = confirmCart.UpdatedOn
            };

            Response.ConfirmCartId = confirmcartDetail.ConfirmCartId;
            return Success();
        }
    }
}
