using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Image;
using Amazon.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Image
{
    public class UpdateImageHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageService _imageService,
        IImageTypeService _imageTypeService)
        : HandlerBase<UpdateImageRequest, UpdateImageResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var image = await _imageService.GetAll()
                .Where(x => x.ImageId == Request.ImageId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (image is null)
                return NotFound($"Image with ID {Request.ImageId} not found");

            var imageType = await _imageTypeService.GetByIdAsync(Request.ImageTypeId);

            if (imageType is null)
                return NotFound($"ImageType with ID {Request.ImageTypeId} not found");

            using (var stream = new System.IO.MemoryStream())
            {
                await Request.Images!.CopyToAsync(stream);

                image.ImageTypeId = Request.ImageTypeId;
                image.Images = stream.ToArray();
                image.ImageName = Request.Images.FileName;
                image.ImageType = Request.Images.ContentType;
                image.UpdatedBy = 101;
                image.UpdatedOn = DateTime.UtcNow;
            }

            await _imageService.UpdateAsync(image);

            var imageDetails = new ImageDto()
            {
                ImageId = image.ImageId,
                ImageTypeId = image.ImageTypeId,
                ProductId = image.ProductId,
                Images = Convert.ToBase64String(image.Images),
                ImageName = image.ImageName,
                ImageType = image.ImageType,
                IsActive = image.IsActive,
                CreatedBy = image.CreatedBy,
                CreatedOn = image.CreatedOn,
                UpdatedBy = image.UpdatedBy,
                UpdatedOn = image.UpdatedOn
            };

            Response.ImageDetails = imageDetails;
            return Success();
        }
    }
}
