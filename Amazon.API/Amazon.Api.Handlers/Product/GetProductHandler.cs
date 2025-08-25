using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class GetProductHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductService _productService)
        : HandlerBase<GetProductRequest, GetProductResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetAll()
                .Include(x => x.ProductDetail)
                .Include(x => x.Reviews)
                .Include(x => x.Images)
                .Include(x => x.ProductTags.Where(z => z.ProductId == x.ProductId).Select(y => y.Tag))
                .Where(x => x.ProductId == Request.ProductId)
                .FirstOrDefaultAsync();

            if (product is null)
                return NotFound($"Product with ID  {Request.ProductId} not found");

            Response.ProductDetails = new ProductDto()
            {
                ProductId = product.ProductId,
                UserId = product.UserId,
                Title = product.Title,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                Rating = product.Rating,
                IsActive = product.IsActive,
                CreatedBy = product.CreatedBy,
                CreatedOn = product.CreatedOn,
                UpdatedBy = product.UpdatedBy,
                UpdatedOn = product.UpdatedOn,
                ProductDetails = new ProductDetailDto()
                {
                    ProductDetailId = product.ProductDetail!.ProductDetailId,
                    ProductId = product.ProductDetail.ProductId,
                    Description = product.ProductDetail.Description,
                    Stock = product.ProductDetail.Stock,
                    Sku = product.ProductDetail.Sku,
                    Weight = product.ProductDetail.Weight,
                    Discount = product.ProductDetail.Discount,
                    Warranty = product.ProductDetail.Warranty,
                    ReturnPolicy = product.ProductDetail.ReturnPolicy,
                    IsActive = product.ProductDetail.IsActive,
                    CreatedBy = product.ProductDetail.CreatedBy,
                    CreatedOn = product.ProductDetail.CreatedOn,
                    UpdatedBy = product.ProductDetail.UpdatedBy,
                    UpdatedOn = product.ProductDetail.UpdatedOn
                },
                Reviews = product.Reviews.Select(x => new ReviewDto()
                {
                    ReviewId = x.ReviewId,
                    ProductId = x.ProductId,
                    ReviewerName = x.ReviewerName,
                    ReviewerEmail = x.ReviewerEmail,
                    Comment = x.Comment,
                    Rating = x.Rating,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedOn = x.UpdatedOn
                }).ToList(),
                ProductTags = product.ProductTags.Select(x => new ProductTagDto()
                {
                    Tag = new List<TagDto>()
                    {
                        new TagDto()
                        {
                            TagId = x.Tag.TagId,
                            Tags = x.Tag.Tags,
                            IsActive = x.Tag.IsActive,
                            CreatedBy = x.Tag.CreatedBy,
                            CreatedOn = x.Tag.CreatedOn,
                            UpdatedBy = x.Tag.UpdatedBy,
                            UpdatedOn = x.Tag.UpdatedOn
                        }
                    },
                }).ToList(),
                Images = product.Images.Select(x => new ImageDto()
                {
                    ImageId = x.ImageId,
                    ProductId = x.ProductId,
                    ImageTypeId = x.ImageTypeId,
                    Images = Convert.ToBase64String(x.Images!),
                    ImageName = x.ImageName,
                    ImageType = x.ImageType,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedOn = x.UpdatedOn
                }).ToList()
            };
            return Success();
        }
    }
}
