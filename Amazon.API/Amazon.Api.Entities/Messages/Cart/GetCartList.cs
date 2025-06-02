using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Cart
{
    public class GetCartListRequest : RequestBase
    {
    }

    public class GetCartListResponse : ResponseBase
    {
        public List<CartDto> Carts { get; set; } = null!;
    }
}
