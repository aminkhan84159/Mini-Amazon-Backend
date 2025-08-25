using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Image;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Image
{
    public class GetImageListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageService _imageService)
        : HandlerBase<GetImageListRequest, GetImageListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var images = await _imageService.GetAll()
                .ToListAsync();

            if (images is null || images.Count == 0)
                return NotFound("No images found");

            //var base64Images = images.Select(x => Convert.ToBase64String(x.Images)).ToList();

            var imageList = images.Select(x => new ImageDto()
            {
                ImageId = x.ImageId,
                ImageTypeId = x.ImageTypeId,
                ProductId = x.ProductId,
                Images = Convert.ToBase64String(x.Images!),
                ImageName = x.ImageName,
                ImageType = x.ImageType,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();

            Response.Images = imageList;
            return Success();
        }
    }
}
