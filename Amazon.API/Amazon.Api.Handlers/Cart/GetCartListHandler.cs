using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Cart;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Cart
{
    public class GetCartListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        ICartService _cartService)
        : HandlerBase<GetCartListRequest, GetCartListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var carts = await _cartService.GetAll()
                .ToListAsync();

            if (carts is null || carts.Count == 0)
                return NotFound("No carts found");

            var cartDtoList = carts.Select(x => new CartDto()
            {
                CartId = x.CartId,
                UserId = x.UserId,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();

            Response.Carts = cartDtoList;
            return Success();
        }
    }
}
