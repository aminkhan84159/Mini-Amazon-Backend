using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Product
{
    public class GetProductRequest : RequestBase
    {
        public int ProductId { get; set; }
    }

    public class GetProductResponse : ResponseBase
    {
        public ProductDto ProductDetails { get; set; } = null!;
    }
}
