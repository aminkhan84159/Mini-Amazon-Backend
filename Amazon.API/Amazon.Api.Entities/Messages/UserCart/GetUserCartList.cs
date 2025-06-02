using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.UserCart
{
    public class GetUserCartListRequest : RequestBase
    {
    }

    public class GetUserCartListResponse : ResponseBase
    {
        public List<UserCartDto> UserCartList { get; set; } = null!;
    }
}
