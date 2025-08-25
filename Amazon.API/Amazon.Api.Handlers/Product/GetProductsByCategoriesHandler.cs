using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class GetProductsByCategoriesHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductService _productService)
        : HandlerBase<GetProductsByCategoriesRequest, GetProductsByCategoriesResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var products = await _productService.GetAll()
                .Where(x => Request.Categories.Contains(x.Category))
                .ToListAsync();

            if (products.Count == 0)
                return NotFound($"No products found for category");
            
            Response.Products = products.Select(x => new Entities.Dtos.ProductDto
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
                UpdatedOn = x.UpdatedOn
            }).ToList();
            return Success();
        }
    }
}
