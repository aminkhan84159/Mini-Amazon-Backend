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
            var user = await _userDataService.GetByIdAsync(Request.UserId);

            if (user is null)
                return NotFound($"User with ID {Request.UserId} not found");

            await _userDataService.DeleteAsync(user);

            var cart = await _cartService.GetAll().Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();

            await _cartService.DeleteAsync(cart);

            Response.UserId = user.UserId;
            return Success();
        }
    }
}
