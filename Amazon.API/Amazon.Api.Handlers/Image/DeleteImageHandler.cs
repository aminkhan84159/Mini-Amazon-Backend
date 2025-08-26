using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Image;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Image
{
    public class DeleteImageHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageService _imageService)
        : HandlerBase<DeleteImageRequest, DeleteImageResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var image = await _imageService.GetAll()
                .Where(x => x.ImageId == Request.ImageId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (image is null)
                return NotFound($"Image with ID {Request.ImageId} not found");

            image.IsActive = false;
            image.UpdatedBy = 101;
            image.UpdatedOn = DateTime.UtcNow;

            await _imageService.UpdateAsync(image);

            Response.ImageId = image.ImageId;
            return Success();
        }
    }
}
