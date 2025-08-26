using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.User;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.User
{
    public class DeleteUserHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserDataService _userDataService,
        ICartService _cartService)
        : HandlerBase<DeleteUserRequest, DeleteUserResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var user = await _userDataService.GetAll()
                .Where(x => x.UserId == Request.UserId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (user is null)
                return NotFound($"User with ID {Request.UserId} not found");

            user.IsActive = false;
            user.UpdatedBy = 101;
            user.UpdatedOn = DateTime.UtcNow;

            await _userDataService.UpdateAsync(user);

            var cart = await _cartService.GetAll()
                .Where(x => x.UserId == user.UserId)
                .FirstOrDefaultAsync();

            cart!.IsActive = false;
            cart.UpdatedBy = 101;
            cart.UpdatedOn = DateTime.UtcNow;

            await _cartService.UpdateAsync(cart);

            Response.UserId = user.UserId;
            return Success();
        }
    }
}
