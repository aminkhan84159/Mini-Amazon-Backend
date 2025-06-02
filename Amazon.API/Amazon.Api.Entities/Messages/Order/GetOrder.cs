using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Order
{
    public class GetOrderRequest : RequestBase
    {
        public int OrderId { get; set; }
    }

    public class GetOrderResponse : ResponseBase
    {
        public OrderDto OrderDetails { get; set; } = null!;
    }
}
