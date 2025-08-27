using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Order
{
    public class AddOrderRequest : RequestBase
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }

    public class AddOrderResponse : ResponseBase
    {
        public int OrderId { get; set; }
    }
}
