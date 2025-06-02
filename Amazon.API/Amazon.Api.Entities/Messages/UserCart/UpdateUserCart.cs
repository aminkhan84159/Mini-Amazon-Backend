using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.UserCart
{
    public class UpdateUserCartRequest : RequestBase
    {
        public int UserCartId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }

    public class UpdateUserCartResponse : ResponseBase
    {
        public UserCartDto UserCartDetails { get; set; } = null!;
    }
}
