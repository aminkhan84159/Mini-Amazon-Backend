using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ConfirmCart;
using Amazon.Api.Services.Interfaces;
using Amazon.Api.Services.Service;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ConfirmCart
{
    public class DeleteConfirmCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IConfirmCartService _confirmCartService)
        : HandlerBase<DeleteConfirmCartRequest, DeleteConfirmCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var confirmCart = await _confirmCartService.GetAll()
                .Where(x => x.CartId == Request.CartId && x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (confirmCart is null)
                return NotFound($"confirm cart with ID {Request.CartId} not found");

            await _confirmCartService.DeleteAsync(confirmCart);

            Response.ConfirmCartId = confirmCart.ConfirmCartId;
            return Success();
        }
    }
}
