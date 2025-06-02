using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Tag
{
    public class DeleteTagRequest : RequestBase
    {
        public int TagId { get; set; }
    }

    public class DeleteTagResponse : ResponseBase
    {
        public int TagId { get; set; }
    }
}
