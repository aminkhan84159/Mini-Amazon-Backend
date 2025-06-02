using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Product
{
    public class GetFilteredProductsRequest : RequestBase
    {
        public string search { get; set; }
    }

    public class GetFilteredProductsResponse : ResponseBase
    {
        public List<ProductDto> products { get; set; }
    }
}
