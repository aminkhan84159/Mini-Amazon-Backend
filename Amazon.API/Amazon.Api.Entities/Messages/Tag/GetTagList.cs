using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Tag
{
    public class GetTagListRequest : RequestBase
    {
    }

    public class GetTagListResponse : ResponseBase
    {
        public List<TagDto> Tags { get; set; } = null!;
    }
}
