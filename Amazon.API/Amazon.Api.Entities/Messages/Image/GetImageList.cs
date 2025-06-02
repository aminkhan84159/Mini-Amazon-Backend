using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Image
{
    public class GetImageListRequest : RequestBase
    {
    }

    public class GetImageListResponse : ResponseBase
    {
        public List<ImageDto> Images { get; set; } = null!;
    }
}
