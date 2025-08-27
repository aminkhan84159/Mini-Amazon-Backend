using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ConfirmCart
{
    public class AddConfirmCartRequest : RequestBase
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }

    public class AddConfirmCartResponse : ResponseBase
    {
        public int ConfirmCartId { get; set; }
    }
}
