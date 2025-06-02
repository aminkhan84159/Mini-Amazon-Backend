using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Cart
{
    public class UpdateCartRequest : RequestBase
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public bool? IsActive { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public class UpdateCartResponse : ResponseBase
    {
        public CartDto CartDetails { get; set; } = null!;
    }
}
