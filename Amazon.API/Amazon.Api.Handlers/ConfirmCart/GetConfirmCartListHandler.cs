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
    public class GetConfirmCartListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IConfirmCartService _confirmCartService)
        : HandlerBase<GetConfirmCartListRequest, GetConfirmCartListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var confirmCarts = await _confirmCartService.GetAll()
                .ToListAsync();

            if (confirmCarts is null || confirmCarts.Count == 0)
                return NotFound("No confirm carts found");

            Response.ConfirmCarts = confirmCarts.Select(x => new ConfirmCartDto
            {
                ConfirmCartId = x.ConfirmCartId,
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
