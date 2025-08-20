using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Tag
{
    public class AddTagRequest : RequestBase
    {
        public string Tags { get; set; } = null!;
    }

    public class AddTagResponse : ResponseBase
    {
        public int TagId { get; set; }
    }
}
