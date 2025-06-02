using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class AddProductHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductService _productService)
        : HandlerBase<AddProductRequest, AddProductResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {

            var existingProduct = await _productService.GetAll()
                .FirstOrDefaultAsync(x => x.Title == Request.Title);

            if (existingProduct is not null)
            {
                if (existingProduct.Title == Request.Title && existingProduct.Category == Request.Category)
                    return Conflict($"Product with title {Request.Title} already exists");
            }

            var product = new Data.Entities.Product()
            {
                Title = Request.Title,
                Brand = Request.Brand,
                Category = Request.Category,
                Price = Request.Price,
                Rating = Request.Rating,
                CreatedBy = 101,
                CreatedOn = DateTime.UtcNow
            };

            await _productService.AddAsync(product);
            
            Response.ProductId = product.ProductId;
            return Success();

        }
    }
}
