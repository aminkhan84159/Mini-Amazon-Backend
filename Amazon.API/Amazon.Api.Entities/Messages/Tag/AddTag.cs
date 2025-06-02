using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Tag
{
    public class AddTagRequest : RequestBase
    {
        public int ProductId { get; set; }
        public List<string> Tags { get; set; }
    }

    public class AddTagResponse : ResponseBase
    {
        public List<int> TagId { get; set; }
    }
}
