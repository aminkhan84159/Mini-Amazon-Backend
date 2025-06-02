using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Image
{
    public class GetImagesByProductIdRequest : RequestBase
    {
        public int ProductId { get; set; }
    }

    public class GetImagesByProductIdResponse : ResponseBase
    {
        public List<ImageDto> Images { get; set; }
    }
}
