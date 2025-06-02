using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.ImageType
{
    public class AddImageTypeRequest : RequestBase
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class AddImageTypeResponse : ResponseBase
    {
        public int ImageTypeId { get; set; }
    }
}
