using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Order
{
    public class UpdateOrderRequest : RequestBase
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }

    public class UpdateOrderResponse : ResponseBase
    {
        public OrderDto OrderDetails { get; set; } = null!;
    }
}
