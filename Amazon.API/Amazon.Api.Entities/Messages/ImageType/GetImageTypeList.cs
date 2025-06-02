using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ImageType
{
    public class GetImageTypeListRequest : RequestBase
    {
    }

    public class GetImageTypeListResponse : ResponseBase
    {
        public List<ImageTypeDto> ImageTypes { get; set; } = null!;
    }
}
