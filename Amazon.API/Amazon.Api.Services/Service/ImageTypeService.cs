using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;

namespace Amazon.Api.Services.Service
{
    public class ImageTypeService : GenericService<ImageType, ImageTypeValidator> , IImageTypeService
    {
        public ImageTypeService(
            AmazonContext amazonContext,
            ImageTypeValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
