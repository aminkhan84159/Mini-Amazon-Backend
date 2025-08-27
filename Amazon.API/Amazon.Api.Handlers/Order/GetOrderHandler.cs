using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Order;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Order
{
    public class GetOrderHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IOrderService _orderService)
        : HandlerBase<GetOrderRequest, GetOrderResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var order = await _orderService.GetAll()
                .Where(x => x.OrderId == Request.OrderId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (order is null)
                return NotFound($"Order with ID {Request.OrderId} not found");

            var orderDetail = new OrderDto()
            {
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                UserId = order.UserId,
                Count = order.Count,
                IsActive = order.IsActive,
                CreatedBy = order.CreatedBy,
                CreatedOn = order.CreatedOn,
                UpdatedBy = order.UpdatedBy,
                UpdatedOn = order.UpdatedOn
            };

            Response.OrderDetails = orderDetail;
            return Success();
        }
    }
}
