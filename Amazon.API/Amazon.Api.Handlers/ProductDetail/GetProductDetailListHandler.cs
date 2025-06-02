using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.ProductDetail;
using Amazon.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ProductDetail
{
    public class GetProductDetailListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductDetailService _productDetailService )
        : HandlerBase<GetProductDetailListRequest, GetProductDetailListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var productDetails = await _productDetailService.GetAll()
                .ToListAsync();

            if (productDetails is null || productDetails.Count == 0)
                return NotFound("No product details found");

            var productDetailList = productDetails.Select(x => new ProductDetailDto()
            {
                ProductDetailId = x.ProductDetailId,
                ProductId = x.ProductId,
                Description = x.Description,
                Stock = x.Stock,
                Sku = x.Sku,
                Weight = x.Weight,
                Warranty = x.Warranty,
                Discount = x.Discount,
                ReturnPolicy = x.ReturnPolicy,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();

            Response.ProductDetails = productDetailList;
            return Success();
        }
    }
}
