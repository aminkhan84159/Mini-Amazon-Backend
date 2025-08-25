using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Image;
using Amazon.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Amazon.Api.Handlers.Image
{
    public class AddImageHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IImageService _imageService,
        IProductService _productService,
        IImageTypeService _imageTypeService)
        : HandlerBase<AddImageRequest, AddImageResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetByIdAsync(Request.ProductId);

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} not found");

            var imageType = await _imageTypeService.GetByIdAsync(Request.ImageTypeId);

            if (imageType is null)
                return NotFound($"ImageType with ID {Request.ImageTypeId} not found");

            if (Request.Images!.Count == 0)
            {
                throw new ArgumentNullException();
            }
            else 
            {
                List<int> imgId = new List<int>();

                foreach (var image in Request.Images) {

                    using (var stream = new System.IO.MemoryStream())
                    {
                        await image.CopyToAsync(stream);

                        var Image = new Data.Entities.Image()
                        {
                            ImageTypeId = Request.ImageTypeId,
                            ProductId = Request.ProductId,
                            Images = stream.ToArray(),
                            ImageName = image.FileName,
                            ImageType = image.ContentType,
                            CreatedBy = 101,
                            CreatedOn = DateTime.UtcNow
                        };

                        await _imageService.AddAsync(Image);

                        imgId.Add(Image.ImageId);
                    }
                    Response.ImageId = imgId;
                };
            }

            return Success();
        }
    }
}
