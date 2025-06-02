using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Image;
using Amazon.Api.Services.Interfaces;
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
            var image = await _imageService.GetByIdAsync(Request.ImageId);

            if (image is null)
                return NotFound($"Image with ID {Request.ImageId} not found");

            await _imageService.DeleteAsync(image);

            Response.ImageId = image.ImageId;
            return Success();
        }
    }
}
