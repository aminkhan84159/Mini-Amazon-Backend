using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.ProductDetail;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ProductDetail
{
    public class GetProductDetailsByProductIdHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductDetailService _productDetailService,
        IProductService _productService)
        : HandlerBase<GetProductDetailsByProductIdRequest, GetProductDetailsByProductIdResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetAll()
                .Where(x => x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} not found");

            var productDetail = await _productDetailService.GetAll()
                .Where(x => x.ProductId == Request.ProductId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (productDetail is null)
                return NotFound($"Product detail for Product ID {Request.ProductId} not found");

            var ProductDetail = new ProductDetailDto
            {
                ProductDetailId = productDetail.ProductDetailId,
                ProductId = productDetail.ProductId,
                Description = productDetail.Description,
                Stock = productDetail.Stock,
                Sku = productDetail.Sku,
                Weight = productDetail.Weight,
                Discount = productDetail.Discount,
                Warranty = productDetail.Warranty,
                ReturnPolicy = productDetail.ReturnPolicy,
                CreatedBy = productDetail.CreatedBy,
                CreatedOn = productDetail.CreatedOn,
                UpdatedBy = productDetail.UpdatedBy,
                UpdatedOn = productDetail.UpdatedOn
            };

            Response.ProductDetail = ProductDetail;
            return Success();
        }
    }
}
