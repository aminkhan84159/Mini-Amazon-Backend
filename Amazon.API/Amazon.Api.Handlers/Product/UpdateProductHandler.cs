using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class UpdateProductHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductService _productService)
        : HandlerBase<UpdateProductRequest, UpdateProductResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetAll()
                .Where(x => x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync(); ;

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} not found");

            var existingProduct = await _productService.GetAll()
                .FirstOrDefaultAsync(x => x.Title == Request.Title && x.IsActive == true);

            if(product.Title != Request.Title)
            {
                if (existingProduct is not null)
                {
                    if (existingProduct.Title == Request.Title && existingProduct.Category == Request.Category)
                        return Conflict($"Product with title {Request.Title} already exists");
                }
            }

            product.Title = Request.Title;
            product.Brand = Request.Brand;
            product.Category = Request.Category;
            product.Price = Request.Price;
            product.Rating = Request.Rating;
            product.UpdatedBy = 101;
            product.UpdatedOn = DateTime.UtcNow;

            await _productService.UpdateAsync(product);

            var productDetails = new ProductDto()
            {
                ProductId = product.ProductId,
                Title = product.Title,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Rating = product.Rating,
                CreatedBy = product.CreatedBy,
                CreatedOn = product.CreatedOn,
                UpdatedBy = product.UpdatedBy,
                UpdatedOn = product.UpdatedOn
            };

            Response.productDetails = productDetails;
            return Success();
        }
    }
}
