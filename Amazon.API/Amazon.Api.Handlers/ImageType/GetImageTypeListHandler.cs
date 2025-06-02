using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.ImageType;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ImageType
{
    public class GetImageTypeListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageTypeService _imageTypeService)
        : HandlerBase<GetImageTypeListRequest, GetImageTypeListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var imageTypes = await _imageTypeService.GetAll().ToListAsync();

            if (imageTypes is null || imageTypes.Count < 0)
                return NotFound("ImageType not found");

            var imageTypeList = imageTypes.Select(x => new ImageTypeDto()
            {
                ImageTypeId = x.ImageTypeId,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();

            Response.ImageTypes = imageTypeList;
            return Success();
        }
    }
}
