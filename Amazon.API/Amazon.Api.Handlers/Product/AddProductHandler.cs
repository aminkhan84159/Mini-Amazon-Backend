using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class AddProductHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductService _productService,
        IHttpContextAccessor _httpContextAccessor)
        : HandlerBase<AddProductRequest, AddProductResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {

            var existingProduct = await _productService.GetAll()
                .FirstOrDefaultAsync(x => x.Title == Request.Title && x.IsActive == true);

            if (existingProduct is not null)
            {
                if (existingProduct.Title == Request.Title && existingProduct.Category == Request.Category)
                    return Conflict($"Product with title {Request.Title} already exists");
            }

            var product = new Data.Entities.Product()
            {
                UserId = int.Parse(_httpContextAccessor.HttpContext!.User.Claims.Where(x => x.Type == "UserId").FirstOrDefault()!.Value),
                Title = Request.Title,
                Brand = Request.Brand,
                Category = Request.Category,
                Price = Request.Price,
                Rating = Request.Rating,
                CreatedBy = 101,
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };

            await _productService.AddAsync(product);
            
            Response.ProductId = product.ProductId;
            return Success();

        }
    }
}
