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
    public class GetConfirmCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IConfirmCartService _confirmCartService)
        : HandlerBase<GetConfirmCartRequest, GetConfirmCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var confirmCart = await _confirmCartService.GetAll()
                .Where(x => x.ConfirmCartId == Request.ConfirmCartId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (confirmCart is null)
                return NotFound($"confirm cart with ID {Request.ConfirmCartId} not found");

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

            Response.ConfirmCart = confirmcartDetail;
            return Success();
        }
    }
}
