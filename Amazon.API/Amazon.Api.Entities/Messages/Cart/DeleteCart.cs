using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Cart
{
    public class DeleteCartRequest : RequestBase
    {
        public int CartId { get; set; }
    }

    public class DeleteCartResponse : ResponseBase
    {
        public int CartId { get; set; }
    }
}
