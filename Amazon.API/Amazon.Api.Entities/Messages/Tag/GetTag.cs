using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Tag
{
    public class GetTagRequest : RequestBase
    {
        public int TagId { get; set; }
    }

    public class GetTagResponse : ResponseBase
    {
        public TagDto TagDetails { get; set; } = null!;
    }
}
