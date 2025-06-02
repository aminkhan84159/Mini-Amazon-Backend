using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Order;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.Order
{
    public class DeleteOrderHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IOrderService _orderService)
        : HandlerBase<DeleteOrderRequest, DeleteOrderResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var order = await _orderService.GetByIdAsync(Request.OrderId);

            if (order is null)
                return NotFound($"Order with ID {Request.OrderId} not found");

            await _orderService.DeleteAsync(order);

            Response.OrderId = order.OrderId;
            return Success();
        }
    }
}
