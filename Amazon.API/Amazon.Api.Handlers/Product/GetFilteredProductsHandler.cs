using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class GetFilteredProductsHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductService _productService)
        : HandlerBase<GetFilteredProductsRequest, GetFilteredProductsResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var products = await _productService.GetAll()
                .Where(x => x.Title.Contains(Request.search) || x.Brand!.Contains(Request.search) && x.IsActive == true)
                .Include(x => x.Images.Where(y => y.IsActive == true))
                .ToListAsync();

            var productList = products.Select(x => new ProductDto
            {
                ProductId = x.ProductId,
                UserId = x.UserId,
                Title = x.Title,
                Brand = x.Brand,
                Category = x.Category,
                Price = x.Price,
                Rating = x.Rating,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn,
                Images = x.Images.Select(y => new ImageDto
                {
                    ImageId = y.ImageId,
                    ProductId = y.ProductId,
                    ImageTypeId = y.ProductId,
                    Images = Convert.ToBase64String(y.Images!),
                    ImageName = y.ImageName,
                    ImageType = y.ImageType,
                    IsActive = y.IsActive,
                    CreatedBy = y.CreatedBy,
                    CreatedOn = y.CreatedOn,
                    UpdatedBy = y.UpdatedBy,
                    UpdatedOn = y.UpdatedOn
                    }).ToList()
                }).ToList();

            Response.products = productList;
            return Success();
        }
    }
}
