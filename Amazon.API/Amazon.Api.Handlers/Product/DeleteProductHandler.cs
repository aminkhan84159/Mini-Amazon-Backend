using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
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
            var product = await _productService.GetByIdAsync(Request.ProductId);

            if (product is null)
               return NotFound($"Product with ID {Request.ProductId} not found");

            await _productService.DeleteAsync(product);

            Response.ProductId = product.ProductId;
            return Success();
        }
    }
}
