using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ConfirmCart
{
    public class UpdateConfirmCartRequest : RequestBase
    {
        public int ConfirmCartId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }

    public class UpdateConfirmCartResponse : ResponseBase
    {
        public int ConfirmCartId { get; set; }
    }
}
