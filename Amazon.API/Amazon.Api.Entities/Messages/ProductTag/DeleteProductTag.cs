using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ProductTag
{
    public class DeleteProductTagRequest : RequestBase
    {
        public int ProductTagId { get; set; }
    }

    public class DeleteProductTagResponse : ResponseBase
    {
        public int ProductTagId { get; set; }
    }
}
