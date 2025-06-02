using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Image
{
    public class DeleteImageRequest : RequestBase
    {
        public int ImageId { get; set; }
    }

    public class DeleteImageResponse : ResponseBase
    {
        public int ImageId { get; set; }
    }
}
