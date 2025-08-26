using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ProductDetail;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Cryptography.Xml;

namespace Amazon.Api.Handlers.ProductDetail
{
    public class AddProductDetailHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductDetailService _productDetailService,
        IProductService _productService)
        : HandlerBase<AddProductDetailRequest, AddProductDetailResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetAll()
                .Where(x => x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} not found");

            var productDeatil = new Data.Entities.ProductDetail()
            {
                ProductId = Request.ProductId,
                Description = Request.Description,
                Stock = Request.Stock,
                Sku = Request.Sku,
                Weight = Request.Weight,
                Discount = Request.Discount,
                Warranty = Request.Warranty,
                ReturnPolicy = Request.ReturnPolicy,
                CreatedBy = 101,
                CreatedOn = DateTime.UtcNow
            };

            await _productDetailService.AddAsync(productDeatil);

            Response.ProductDetailId = productDeatil.ProductDetailId;
            return Success();
        }
    }
}
