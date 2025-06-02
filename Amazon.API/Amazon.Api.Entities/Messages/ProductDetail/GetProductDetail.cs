using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ProductDetail
{
    public class GetProductDetailRequest : RequestBase
    {
        public int ProductDetailId { get; set; }
    }

    public class GetProductDetailResponse : ResponseBase
    {
        public ProductDetailDto ProductDetails { get; set; } = null!;
    }
}
