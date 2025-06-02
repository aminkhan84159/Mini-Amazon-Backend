using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Product
{
    public class GetProductsByCategoriesRequest : RequestBase
    {
        public List<string> Categories { get; set; }
    }

    public class GetProductsByCategoriesResponse : ResponseBase
    {
        public List<ProductDto> Products { get; set; } = null!;
    }
}
