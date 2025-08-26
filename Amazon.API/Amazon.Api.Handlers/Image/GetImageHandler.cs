using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Image;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Image
{
    public class GetImageHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageService _imageService)
        : HandlerBase<GetImageRequest, GetImageResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var image = await _imageService.GetAll()
                .Where(x => x.ImageId == Request.ImageId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (image is null)
                return NotFound($"Image with ID {Request.ImageId} not found");

            var imageDetail = new ImageDto()
            {
                ImageId = image.ImageId,
                ImageTypeId = image.ImageTypeId,
                ProductId = image.ProductId,
                Images = Convert.ToBase64String(image.Images!),
                ImageName = image.ImageName,
                ImageType = image.ImageType,
                IsActive = image.IsActive,
                CreatedBy = image.CreatedBy,
                CreatedOn = image.CreatedOn,
                UpdatedBy = image.UpdatedBy,
                UpdatedOn = image.UpdatedOn
            };

            Response.ImageDetails = imageDetail;
            return Success();
        }
    }
}
