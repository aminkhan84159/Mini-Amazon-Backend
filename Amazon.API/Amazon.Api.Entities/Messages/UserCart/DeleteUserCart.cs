using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.UserCart
{
    public class DeleteUserCartRequest : RequestBase
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }

    public class DeleteUserCartResponse : ResponseBase
    {
        public int UserCartId { get; set; }
    }
}
