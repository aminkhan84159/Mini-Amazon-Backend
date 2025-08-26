using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.ImageType;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ImageType
{
    public class GetImageTypeHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageTypeService _imageTypeService)
        : HandlerBase<GetImageTypeRequest, GetImageTypeResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var imageType = await _imageTypeService.GetAll()
                .Where(x => x.ImageTypeId == Request.ImageTypeId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (imageType is null)
                return NotFound($"ImageType with ID {Request.ImageTypeId} not found");

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
