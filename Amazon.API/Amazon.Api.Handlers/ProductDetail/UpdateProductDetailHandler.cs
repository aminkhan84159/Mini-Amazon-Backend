using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.ProductDetail;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.ProductDetail
{
    public class UpdateProductDetailHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductDetailService _productDetailService)
        : HandlerBase<UpdateProductDetailRequest, UpdateProductDetailResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var productDetail = await _productDetailService.GetByIdAsync(Request.ProductDetailId);

            if (productDetail == null)
                return NotFound($"Product detail with ID {Request.ProductDetailId} not found");

            productDetail.Description = Request.Description;
            productDetail.Stock = Request.Stock;
            productDetail.Sku = Request.Sku;
            productDetail.Weight = Request.Weight;
            productDetail.Discount = Request.Discount;
            productDetail.Warranty = Request.Warranty;
            productDetail.ReturnPolicy = Request.ReturnPolicy;
            productDetail.UpdatedBy = 101;
            productDetail.UpdatedOn = DateTime.UtcNow;

            await _productDetailService.UpdateAsync(productDetail);

            var ProductDetail = new ProductDetailDto()
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
                IsActive = productDetail.IsActive,
                CreatedBy = productDetail.CreatedBy,
                CreatedOn = productDetail.CreatedOn,
                UpdatedBy = productDetail.UpdatedBy,
                UpdatedOn = productDetail.UpdatedOn
            };

            Response.ProductDetails = ProductDetail;
            return Success();
        }
    }
}
