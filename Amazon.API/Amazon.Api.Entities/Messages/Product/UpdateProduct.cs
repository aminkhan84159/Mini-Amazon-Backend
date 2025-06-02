using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Product
{
    public class UpdateProductRequest : RequestBase
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = null!;
        public string? Brand { get; set; }
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? Rating { get; set; }
        public string? Thumbnail { get; set; }
    }

    public class UpdateProductResponse : ResponseBase
    {
        public ProductDto productDetails { get; set; } = null!;
    }
}
