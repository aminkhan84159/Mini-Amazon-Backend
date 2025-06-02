using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ProductDetail
{
    public class GetProductDetailListRequest : RequestBase
    {
    }

    public class GetProductDetailListResponse : ResponseBase
    {
        public List<ProductDetailDto> ProductDetails { get; set; } = null!;
    }
}
