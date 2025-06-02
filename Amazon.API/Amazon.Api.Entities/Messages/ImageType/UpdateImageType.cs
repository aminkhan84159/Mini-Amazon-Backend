using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.ImageType
{
    public class UpdateImageTypeRequest : RequestBase
    {
        public int ImageTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class UpdateImageTypeResponse : ResponseBase
    {
        public ImageTypeDto ImageTypeDetails { get; set; } = null!;
    }
}
