using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Cart
{
    public class GetCartRequest : RequestBase
    {
        public int CartId { get; set; }
    }

    public class GetCartResponse : ResponseBase
    {
        public CartDto CartDetails { get; set; } = null!;
    }
}
