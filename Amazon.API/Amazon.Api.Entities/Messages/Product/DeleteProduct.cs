using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Product
{
    public class DeleteProductRequest : RequestBase
    {
        public int ProductId { get; set; }
    }

    public class DeleteProductResponse : ResponseBase
    {
        public int ProductId { get; set; }
    }
}
