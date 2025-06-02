using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ProductDetail
{
    public class AddProductDetailRequest : RequestBase
    {
        public int ProductId { get; set; }
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
        public string Sku { get; set; } = null!;
        public decimal Weight { get; set; }
        public int? Discount { get; set; }
        public string Warranty { get; set; } = null!;
        public string ReturnPolicy { get; set; } = null!;
    }

    public class AddProductDetailResponse : ResponseBase
    {
        public int ProductDetailId { get; set; }
    }
}
