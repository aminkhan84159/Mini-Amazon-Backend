using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ImageType;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ImageType
{
    public class AddImageTypeHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageTypeService _imageTypeService)
        : HandlerBase<AddImageTypeRequest, AddImageTypeResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var existingImageType = await _imageTypeService.GetAll()
                .FirstOrDefaultAsync(x => x.Name == Request.Name && x.IsActive == true);

            if (existingImageType is not null)
            {
                if (existingImageType.Name == Request.Name)
                    return Conflict($"ImageType with name {Request.Name} already exists");
            }

            var imageType = new Data.Entities.ImageType()
            {
                Name = Request.Name,
                Description = Request.Description,
                CreatedBy = 101,
                CreatedOn = DateTime.UtcNow
            };

            await _imageTypeService.AddAsync(imageType);

            Response.ImageTypeId = imageType.ImageTypeId;
            return Success();
        }
    }
}
