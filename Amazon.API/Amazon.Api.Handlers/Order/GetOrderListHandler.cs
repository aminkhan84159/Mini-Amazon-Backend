using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Order;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Order
{
    public class GetOrderListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IOrderService _orderService)
        : HandlerBase<GetOrderListRequest, GetOrderListResponse>(_logger, _amazonContext) 
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var orders = await _orderService.GetAll()
                .ToListAsync();

            if (orders is null || orders.Count == 0)
                return NotFound("No orders found");

            var orderList = orders.Select(x => new OrderDto()
            {
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UserId = x.UserId,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();

            Response.Orders = orderList;
            return Success();
        }
    }
}
