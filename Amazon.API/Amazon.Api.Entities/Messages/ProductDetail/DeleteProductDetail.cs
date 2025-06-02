using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ProductDetail
{
    public class DeleteProductDetailRequest : RequestBase
    {
        public int ProductDetailId { get; set; }
    }

    public class DeleteProductDetailResponse : ResponseBase
    {
        public int ProductDetailId { get; set; }
    }
}
