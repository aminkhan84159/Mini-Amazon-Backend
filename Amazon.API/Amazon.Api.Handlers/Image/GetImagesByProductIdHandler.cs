using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Image;
using Amazon.Api.Services.Interfaces;
using Azure.Core.GeoJson;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Image
{
    public class GetImagesByProductIdHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageService _imageService,
        IProductService _productService)
        : HandlerBase<GetImagesByProductIdRequest, GetImagesByProductIdResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetByIdAsync(Request.ProductId);

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} Not found");

            var images = await _imageService.GetAll()
                .Where(x => x.ProductId == Request.ProductId).ToListAsync();

            if (images is null || images.Count == 0)
                return NotFound("No Images found");

            var imageList = images.Select(x => new ImageDto
            {
                ImageId = x.ImageId,
                ProductId = x.ProductId,
                ImageTypeId = x.ImageTypeId,
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
