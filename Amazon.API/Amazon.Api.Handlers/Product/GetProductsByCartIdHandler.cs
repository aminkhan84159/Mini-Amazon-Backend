using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class GetProductsByCartIdHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserCartService _userCartService,
        ICartService _cartService)
        : HandlerBase<GetProductsByCartIdRequest, GetProductsByCartIdResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var cart = await _cartService.GetByIdAsync(Request.CartId);

            if (cart is null)
                return NotFound($"Cart with ID {Request.CartId} Not found");

            var products = await _userCartService.GetAll()
                .Where(x => x.CartId == Request.CartId)
                .Include(x => x.Product.ProductDetail)
                .Include(x => x.Product.Images)
                .Select(x => x.Product).ToListAsync();

            if (products is null || products.Count == 0)
                return NotFound("No Products found");

            var productList = products.Select(x => new ProductDto
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
                UpdatedOn = x.UpdatedOn,
                Images = x.Images.Select(y => new ImageDto
                {
                    ImageId = y.ImageId,
                    ProductId = y.ProductId,
                    ImageTypeId = y.ProductId,
                    Images = Convert.ToBase64String(y.Images!),
                    ImageName = y.ImageName,
                    ImageType = y.ImageType,
                    IsActive = y.IsActive,
                    CreatedBy = y.CreatedBy,
                    CreatedOn = y.CreatedOn,
                    UpdatedBy = y.UpdatedBy,
                    UpdatedOn = y.UpdatedOn
                }).ToList(),
                ProductDetails = new ProductDetailDto()
                {
                    ProductDetailId = x.ProductDetail!.ProductDetailId,
                    ProductId = x.ProductDetail.ProductId,
                    Description = x.ProductDetail.Description,
                    Stock = x.ProductDetail.Stock,
                    Sku = x.ProductDetail.Sku,
                    Weight = x.ProductDetail.Weight,
                    Discount = x.ProductDetail.Discount,
                    Warranty = x.ProductDetail.Warranty,
                    ReturnPolicy = x.ProductDetail.ReturnPolicy,
                    IsActive = x.ProductDetail.IsActive,
                    CreatedBy = x.ProductDetail.CreatedBy,
                    CreatedOn = x.ProductDetail.CreatedOn,
                    UpdatedBy = x.ProductDetail.UpdatedBy,
                    UpdatedOn = x.ProductDetail.UpdatedOn
                }
            }).ToList();

            Response.Products = productList;
            return Success();
        }
    }
}
