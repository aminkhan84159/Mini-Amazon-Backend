using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Order;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Order
{
    public class AddOrderHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IOrderService _orderService,
        IProductService _productService,
        IUserDataService _userService)
        : HandlerBase<AddOrderRequest, AddOrderResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetAll()
                .Where(x => x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} Not found");

            var user = await _userService.GetAll()
                .Where(x => x.UserId == Request.UserId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (user is null)
                return NotFound($"User with ID {Request.UserId} Not found");

            var order = new Data.Entities.Order()
            {
                UserId = Request.UserId,
                ProductId = Request.ProductId,
                Count = Request.Count,
                CreatedBy = 101,
                CreatedOn = DateTime.UtcNow,
            };

            await _orderService.AddAsync(order);

            Response.OrderId = order.OrderId;
            return Success();
        }
    }
}
