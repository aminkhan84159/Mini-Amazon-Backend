using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Image
{
    public class GetImageRequest : RequestBase
    {
        public int ImageId { get; set; }
    }

    public class GetImageResponse : ResponseBase
    {
        public ImageDto ImageDetails { get; set; } = null!;
    }
}
