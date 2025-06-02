using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Order;
using Amazon.Api.Services.Interfaces;
using Amazon.Api.Services.Service;
using Serilog;

namespace Amazon.Api.Handlers.Order
{
    public class UpdateOrderHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IOrderService _orderService,
        IProductService _productService,
        IUserDataService _userService)
        : HandlerBase<UpdateOrderRequest, UpdateOrderResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var order = await _orderService.GetByIdAsync(Request.OrderId);

            if (order is null)
                return NotFound($"Order with ID {Request.OrderId} Not found");

            var product = await _productService.GetByIdAsync(Request.ProductId);

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} Not found");

            var user = await _userService.GetByIdAsync(Request.UserId);

            if (user is null)
                return NotFound($"User with ID {Request.UserId} Not found");

            order.ProductId = Request.ProductId;
            order.UserId = Request.UserId;
            order.UpdatedBy = 101;
            order.UpdatedOn = DateTime.UtcNow;

            await _orderService.UpdateAsync(order);

            var orderDetails = new OrderDto()
            {
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                UserId = order.UserId,
                IsActive = order.IsActive,
                CreatedBy = order.CreatedBy,
                CreatedOn = order.CreatedOn,
                UpdatedBy = order.UpdatedBy,
                UpdatedOn = order.UpdatedOn
            };

            Response.OrderDetails = orderDetails;
            return Success();
        }
    }
}
