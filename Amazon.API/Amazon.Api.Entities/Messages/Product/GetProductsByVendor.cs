using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Product
{
    public class GetProductsByVendorRequest : RequestBase
    {
        public int UserId { get; set; }
    }

    public class GetProductsByVendorResponse : ResponseBase
    {
        public List<ProductDto> Products { get; set; } = null!;
    }
}
