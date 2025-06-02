using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.UserCart;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.UserCart
{
    public class DeleteUserCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserCartService _usercartService)
        : HandlerBase<DeleteUserCartRequest, DeleteUserCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var userCart = await _usercartService.GetAll()
                .Where(x => x.CartId == Request.CartId && x.ProductId == Request.ProductId)
                .FirstOrDefaultAsync();

            if (userCart is null)
                return NotFound($"User cart with ID {Request.CartId} not found");

            await _usercartService.DeleteAsync(userCart);

            Response.UserCartId = userCart.UserCartId;
            return Success();
        }
    }
}
