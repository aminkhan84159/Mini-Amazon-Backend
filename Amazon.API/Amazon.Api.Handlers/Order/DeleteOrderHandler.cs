using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Order;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var order = await _orderService.GetAll()
                .Where(x => x.OrderId == Request.OrderId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (order is null)
                return NotFound($"Order with ID {Request.OrderId} not found");

            order.IsActive = false;
            order.UpdatedBy = 101;
            order.UpdatedOn = DateTime.UtcNow;

            await _orderService.UpdateAsync(order);

            Response.OrderId = order.OrderId;
            return Success();
        }
    }
}
