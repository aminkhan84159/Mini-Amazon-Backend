using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ConfirmCart
{
    public class GetConfirmCartListRequest : RequestBase
    {
    }

    public class GetConfirmCartListResponse : ResponseBase
    {
        public List<ConfirmCartDto> ConfirmCarts { get; set; } = null!;
    }
}
