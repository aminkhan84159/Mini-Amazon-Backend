using Amazon.Api.Core.ServiceFramework.Messages;
using Microsoft.AspNetCore.Http;

namespace Amazon.Api.Entities.Messages.Image
{
    public class AddImageRequest : RequestBase
    {
        public int ImageTypeId { get; set; }
        public int ProductId { get; set; }
        public IFormFileCollection? Images { get; set; }
    }

    public class AddImageResponse : ResponseBase
    {
        public List<int> ImageId { get; set; }
    }
}
