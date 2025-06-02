using Amazon.Api.Business.Manager;
using Amazon.Api.Entities.Messages.Order;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(
        ILogger<OrderController> logger,
        OrderManager orderManager)
        : GenericController<GetOrderRequest, AddOrderRequest, UpdateOrderRequest, DeleteOrderRequest>(logger, orderManager)
    {
    }
}
