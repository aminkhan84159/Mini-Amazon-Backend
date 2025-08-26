using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.UserCart;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.UserCart
{
    public class GetUserCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserCartService _userCartService)
        : HandlerBase<GetUserCartRequest, GetUserCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var userCart = await _userCartService.GetAll()
                .Where(x => x.UserCartId == Request.UserCartId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (userCart is null)
                return NotFound($"User cart with ID {Request.UserCartId} not found");

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
