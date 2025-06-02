using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ImageType
{
    public class GetImageTypeRequest : RequestBase
    {
        public int ImageTypeId { get; set; }
    }

    public class GetImageTypeResponse : ResponseBase
    {
        public ImageTypeDto ImageTypeDetails { get; set; } = null!;
    }
}
