using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Order
{
    public class DeleteOrderRequest : RequestBase
    {
        public int OrderId { get; set; }
    }

    public class DeleteOrderResponse : ResponseBase
    {
        public int OrderId { get; set; }
    }
}
