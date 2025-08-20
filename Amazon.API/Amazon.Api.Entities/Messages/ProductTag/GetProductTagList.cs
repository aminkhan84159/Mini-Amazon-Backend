using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ProductTag
{
    public class GetProductTagListRequest : RequestBase
    {
    }

    public class GetProductTagListResponse : ResponseBase
    {
        public List<ProductTagDto> ProductTags { get; set; } = null!;
    }
}
