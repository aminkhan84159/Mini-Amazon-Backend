using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Product
{
    public class GetProductsFromConfirmCartRequest : RequestBase
    {
        public int CartId { get; set; }
    }

    public class  GetProductsFromConfirmCartResponse : ResponseBase
    {
        public List<ProductDto> Products { get; set; } = null!;
    }
}
