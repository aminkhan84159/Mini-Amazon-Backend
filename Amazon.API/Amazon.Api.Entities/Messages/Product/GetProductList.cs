using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Product
{
    public class GetProductListRequest : RequestBase
    {
    }

    public class GetProductListResponse : ResponseBase
    {
        public List<ProductDto> Products { get; set; } = null!;
    }
}
