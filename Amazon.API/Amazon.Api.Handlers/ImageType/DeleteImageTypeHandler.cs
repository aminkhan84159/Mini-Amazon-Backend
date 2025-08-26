using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ImageType;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var imageType = await _imageTypeService.GetAll()
                .Where(x => x.ImageTypeId == Request.ImageTypeId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (imageType is null)
                return NotFound($"ImageType with ID {Request.ImageTypeId} not found");

            imageType.IsActive = false;
            imageType.UpdatedBy = 101;
            imageType.UpdatedOn = DateTime.UtcNow;

            await _imageTypeService.UpdateAsync(imageType);

            Response.ImageTypeId = imageType.ImageTypeId;
            return Success();
        }
    }
}
