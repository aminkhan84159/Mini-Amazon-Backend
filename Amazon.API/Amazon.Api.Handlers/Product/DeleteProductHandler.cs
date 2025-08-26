using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class DeleteProductHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductService _productService)
        : HandlerBase<DeleteProductRequest, DeleteProductResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetAll()
                .Where(x => x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (product is null)
               return NotFound($"Product with ID {Request.ProductId} not found");

            product.IsActive = false;
            product.UpdatedBy = 101;
            product.UpdatedOn = DateTime.UtcNow;

            await _productService.UpdateAsync(product);

            Response.ProductId = product.ProductId;
            return Success();
        }
    }
}
