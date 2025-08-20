using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ProductTag
{
    public class GetProductTagRequest : RequestBase
    {
        public int ProductTagId { get; set; }
    }

    public class GetProductTagResponse : ResponseBase
    {
        public ProductTagDto ProductTagDetails { get; set; } = null!;
    }
}
