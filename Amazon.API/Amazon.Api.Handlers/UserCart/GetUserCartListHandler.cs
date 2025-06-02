using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.UserCart;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.UserCart
{
    public class GetUserCartListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserCartService _userCartService)
        : HandlerBase<GetUserCartListRequest, GetUserCartListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var userCarts = await _userCartService.GetAll()
                .ToListAsync();

            if (userCarts is null || userCarts.Count == 0)
                return NotFound("No user carts found");

            Response.UserCartList = userCarts.Select(x => new UserCartDto
            {
                UserCartId = x.UserCartId,
                ProductId = x.ProductId,
                CartId = x.CartId,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();

            return Success();
        }
    }
}
