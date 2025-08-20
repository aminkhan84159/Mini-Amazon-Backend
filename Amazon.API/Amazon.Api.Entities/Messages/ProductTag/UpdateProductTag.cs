using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ProductTag
{
    public class UpdateProductTagRequest : RequestBase
    {
        public int ProductTagId { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
    }

    public class UpdateProductTagResponse : ResponseBase
    {
        public int ProductTagId { get; set; }
    }
}
