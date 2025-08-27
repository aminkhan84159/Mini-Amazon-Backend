using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Product
{
    public class GetOrderedProductsByUserIdRequest : RequestBase
    {
        public int UserId { get; set; }
    }

    public class GetOrderedProductsByUserIdResponse : ResponseBase
    {
        public List<OrderDto> Orders { get; set; } = null!;
        public List<ProductDto> Products { get; set; } = null!;
    }
}
