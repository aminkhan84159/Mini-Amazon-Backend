using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ProductDetail
{
    public class GetProductDetailsByProductIdRequest : RequestBase
    {
        public int ProductId { get; set; }
    }

    public class GetProductDetailsByProductIdResponse : ResponseBase
    {
        public ProductDetailDto ProductDetail { get; set; } = null!;
    }
}
