using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.UserCart
{
    public class AddUserCartRequest : RequestBase
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
    }

    public class AddUserCartResponse : ResponseBase
    {
        public int UserCartId { get; set; }
    }
}
