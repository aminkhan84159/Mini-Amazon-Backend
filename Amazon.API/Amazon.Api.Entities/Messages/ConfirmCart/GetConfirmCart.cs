using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ConfirmCart
{
    public class GetConfirmCartRequest : RequestBase
    {
        public int ConfirmCartId { get; set; }
    }

    public class GetConfirmCartResponse : ResponseBase
    {
        public ConfirmCartDto ConfirmCart { get; set; } = null!;
    }
}
