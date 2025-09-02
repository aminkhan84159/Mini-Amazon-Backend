using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class GetProductsByVendorHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserDataService _userDataService,
        IProductService _productService)
        : HandlerBase<GetProductsByVendorRequest, GetProductsByVendorResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var user = await _userDataService.GetByIdAsync(Request.UserId);

            if (user == null || user.Role != "Vendor" || user.IsActive == false)
                return NotFound($"Vendor with ID {Request.UserId} not found or is not active.");

            var products = await _productService.GetAll()
                .Where(x => x.UserId == Request.UserId && x.IsActive == true)
                .Include(x => x.ProductDetail)
                .Include(x => x.Images.Where(i => i.IsActive == true))
                .Include(x => x.ProductTags.Where(t => t.IsActive == true))
                    .ThenInclude(y => y.Tag)
                .Include(x => x.Reviews.Where(r => r.IsActive == true))
                .ToListAsync();

            if (products.Count == 0)
                return Success($"No products found for vendor with ID {Request.UserId}.");

            var Products = products.Select(x => new Entities.Dtos.ProductDto()
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
                ProductDetails = new Entities.Dtos.ProductDetailDto
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
                },
                Images = x.Images.Select(y => new Entities.Dtos.ImageDto
                {
                    ImageId = y.ImageId,
                    ProductId = y.ProductId,
                    ImageTypeId = y.ImageTypeId,
                    Images = Convert.ToBase64String(y.Images!),
                    ImageName = y.ImageName,
                    ImageType = y.ImageType,
                    IsActive = y.IsActive,
                    CreatedBy = y.CreatedBy,
                    CreatedOn = y.CreatedOn,
                    UpdatedBy = y.UpdatedBy,
                    UpdatedOn = y.UpdatedOn
                }).ToList(),
                Reviews = x.Reviews.Select(r => new ReviewDto()
                {
                    ReviewId = r.ReviewId,
                    ProductId = r.ProductId,
                    ReviewerName = r.ReviewerName,
                    ReviewerEmail = r.ReviewerEmail,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    IsActive = r.IsActive,
                    CreatedBy = r.CreatedBy,
                    CreatedOn = r.CreatedOn,
                    UpdatedBy = r.UpdatedBy,
                    UpdatedOn = r.UpdatedOn
                }).ToList(),
                Tag = x.ProductTags
                  .Where(y => y.IsActive == true)

                      .Select(y => new TagDto()
                      {
                          TagId = y.Tag!.TagId,
                          Tags = y.Tag.Tags,
                          IsActive = y.Tag.IsActive,
                          CreatedBy = y.Tag.CreatedBy,
                          CreatedOn = y.Tag.CreatedOn,
                          UpdatedBy = y.Tag.UpdatedBy,
                          UpdatedOn = y.Tag.UpdatedOn
                      }).ToList()
            }).ToList();

            Response.Products = Products;
            return Success();
        }
    }
}
