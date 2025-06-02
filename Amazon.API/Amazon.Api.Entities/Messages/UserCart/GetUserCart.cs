using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.UserCart
{
    public class GetUserCartRequest : RequestBase
    {
        public int UserCartId { get; set; }
    }

    public class  GetUserCartResponse : ResponseBase
    {
        public UserCartDto UserCartDetails { get; set; } = null!;
    }
}
