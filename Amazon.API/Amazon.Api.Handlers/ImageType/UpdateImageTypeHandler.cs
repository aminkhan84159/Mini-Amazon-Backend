using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.ImageType;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ImageType
{
    public class UpdateImageTypeHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageTypeService _imageTypeService)
        : HandlerBase<UpdateImageTypeRequest, UpdateImageTypeResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var imageType = await _imageTypeService.GetByIdAsync(Request.ImageTypeId);

            if (imageType is null)
                return NotFound($"ImageType with ID {Request.ImageTypeId} not found");

            var existingImageType = await _imageTypeService.GetAll()
                .FirstOrDefaultAsync(x => x.Name == Request.Name);

            if (imageType.Name != Request.Name)
            {
                if (existingImageType is not null)
                {
                    if (existingImageType.Name == Request.Name)
                        return Conflict($"ImageType with name {Request.Name} already exists");
                }
            }

            imageType.Name = Request.Name;
            imageType.Description = Request.Description;
            imageType.UpdatedBy = 101;
            imageType.UpdatedOn = DateTime.UtcNow;

            await _imageTypeService.UpdateAsync(imageType);

            var imageTypeDetails = new ImageTypeDto()
            {
                ImageTypeId = imageType.ImageTypeId,
                Name = imageType.Name,
                Description = imageType.Description,
                IsActive = imageType.IsActive,
                CreatedBy = imageType.CreatedBy,
                CreatedOn = imageType.CreatedOn,
                UpdatedBy = imageType.UpdatedBy,
                UpdatedOn = imageType.UpdatedOn
            };

            Response.ImageTypeDetails = imageTypeDetails;
            return Success();
        }
    }
}
