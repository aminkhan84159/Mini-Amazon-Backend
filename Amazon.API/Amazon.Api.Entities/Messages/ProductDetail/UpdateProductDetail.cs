using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ProductDetail
{
    public class UpdateProductDetailRequest : RequestBase
    {
        public int ProductDetailId { get; set; }
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
        public string Sku { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal? Discount { get; set; }
        public string Warranty { get; set; } = null!;
        public string ReturnPolicy { get; set; } = null!;
    }

    public class UpdateProductDetailResponse : ResponseBase
    {
        public ProductDetailDto ProductDetails { get; set; } = null!;
    }
}
