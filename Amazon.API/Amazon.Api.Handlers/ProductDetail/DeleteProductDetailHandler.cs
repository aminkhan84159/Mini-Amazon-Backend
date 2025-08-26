using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ProductDetail;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ProductDetail
{
    public class DeleteProductDetailHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductDetailService _productDetailService)
        : HandlerBase<DeleteProductDetailRequest, DeleteProductDetailResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var productDetail = await _productDetailService.GetAll()
                .Where(x => x.ProductDetailId == Request.ProductDetailId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (productDetail is null)
                return NotFound($"Product detail with ID {Request.ProductDetailId} not found");

            productDetail.IsActive = false;
            productDetail.UpdatedBy = 101;
            productDetail.UpdatedOn = DateTime.UtcNow;

            await _productDetailService.UpdateAsync(productDetail);

            Response.ProductDetailId = productDetail.ProductDetailId;
            return Success();
        }
    }
}
