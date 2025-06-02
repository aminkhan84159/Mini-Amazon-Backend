using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;
using System.Security.AccessControl;

namespace Amazon.Api.Services.Service
{
    public class ImageService : GenericService<Image, ImageValidator>, IImageService
    {
        public ImageService(
            AmazonContext amazonContext,
            ImageValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
