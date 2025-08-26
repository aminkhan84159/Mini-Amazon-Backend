using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.ProductDetail;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ProductDetail
{
    public class GetProductDetailHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductDetailService _productDetailService)
        : HandlerBase<GetProductDetailRequest, GetProductDetailResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var productDetail = await _productDetailService.GetAll()
                .Where(x => x.ProductDetailId == Request.ProductDetailId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (productDetail is null)
                return NotFound($"Product detail with ID {Request.ProductDetailId} not found");

            var productDetails = new ProductDetailDto()
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

            await _productDetailService.UpdateAsync(productDetail);

            Response.ProductDetails = productDetails;
            return Success();
        }
    }
}
