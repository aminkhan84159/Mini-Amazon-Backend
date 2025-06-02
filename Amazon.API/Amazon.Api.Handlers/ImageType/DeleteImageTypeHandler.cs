using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ImageType;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.ImageType
{
    public class DeleteImageTypeHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageTypeService _imageTypeService)
        : HandlerBase<DeleteImageTypeRequest, DeleteImageTypeResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var imageType = await _imageTypeService.GetByIdAsync(Request.ImageTypeId);

            if (imageType is null)
                return NotFound($"ImageType with ID {Request.ImageTypeId} not found");

            await _imageTypeService.DeleteAsync(imageType);

            Response.ImageTypeId = imageType.ImageTypeId;
            return Success();
        }
    }
}
