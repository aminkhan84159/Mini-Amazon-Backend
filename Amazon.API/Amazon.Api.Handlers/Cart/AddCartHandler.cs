using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Cart;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.Cart
{
    public class AddCartHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        ICartService _cartService,
        IUserDataService _userDataService)
        : HandlerBase<AddCartRequest, AddCartResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var user = await _userDataService.GetByIdAsync(Request.UserId);

            if (user is null)
                return NotFound($"User with ID  {Request.UserId} not found");

            var cart = new Data.Entities.Cart()
            {
                UserId = Request.UserId,
                CreatedBy = Request.UserId,
                CreatedOn = DateTime.UtcNow
            };

            await _cartService.AddAsync(cart);

            Response.CartId = cart.CartId;
            return Success();
        }
    }
}
