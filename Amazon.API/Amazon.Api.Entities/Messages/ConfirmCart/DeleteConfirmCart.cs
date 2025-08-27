using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ConfirmCart
{
    public class DeleteConfirmCartRequest : RequestBase
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }

    public class DeleteConfirmCartResponse : ResponseBase
    {
        public int ConfirmCartId { get; set; }
    }
}
