using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Tag
{
    public class UpdateTagRequest : RequestBase
    {
        public int TagId { get; set; }
        public string? Tags { get; set; }
    }

    public class UpdateTagResponse : ResponseBase
    {
        public TagDto TagDetails { get; set; } = null!;
    }
}
