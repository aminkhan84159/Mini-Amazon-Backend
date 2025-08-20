using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ProductTag
{
    public class AddProductTagRequest : RequestBase
    {
        public int ProductId { get; set; }
        public int TagId { get; set; }
    }

    public class AddProductTagResponse : ResponseBase
    {
        public int ProductTagId { get; set; }
    }
}
