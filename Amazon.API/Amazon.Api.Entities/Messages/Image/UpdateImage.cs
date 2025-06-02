using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Amazon.Api.Entities.Messages.Image
{
    public class UpdateImageRequest : RequestBase
    {
        public int ImageId { get; set; }
        public int ImageTypeId { get; set; }
        public IFormFile? Images { get; set; }
    }

    public class UpdateImageResponse : ResponseBase
    {
        public ImageDto ImageDetails { get; set; } = null!;
    }
}
