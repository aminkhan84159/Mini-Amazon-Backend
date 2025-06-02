using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ImageType
{
    public class DeleteImageTypeRequest : RequestBase
    {
        public int ImageTypeId { get; set; }
    }

    public class DeleteImageTypeResponse : ResponseBase
    {
        public int ImageTypeId { get; set; }
    }
}
