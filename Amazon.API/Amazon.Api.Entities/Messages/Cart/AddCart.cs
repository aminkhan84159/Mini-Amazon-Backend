using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Cart
{
    public class AddCartRequest : RequestBase
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class AddCartResponse : ResponseBase
    {
        public int CartId { get; set; }
    }
}
