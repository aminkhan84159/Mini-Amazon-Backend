using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Product
{
    public class GetOrderedProductsByUserIdHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserDataService _userService,
        IOrderService _orderService)
        : HandlerBase<GetOrderedProductsByUserIdRequest, GetOrderedProductsByUserIdResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var user = await _userService.GetByIdAsync(Request.UserId);

            if (user is null)
                return NotFound($"User with ID  {Request.UserId} not found");

            var orders = await _orderService.GetAll()
                .Where(x => x.UserId == Request.UserId && x.IsActive == true)
                .Include(x => x.Product)
                    .ThenInclude(y => y.ProductDetail)
                .ToListAsync();

            if (orders == null || orders.Count == 0)
                return NotFound("No Orders found");

            var order = orders.Select(x => new OrderDto
            {
                OrderId = x.OrderId,
                UserId = x.UserId,
                ProductId = x.ProductId,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn,
                Products = new List<ProductDto>()
                {
                    new ProductDto()
                    {
                        ProductId = x.Product!.ProductId,
                        UserId = x.Product.UserId,
                        Title = x.Product.Title,
                        Brand = x.Product.Brand,
                        Category = x.Product.Category,
                        Price = x.Product.Price,
                        Rating = x.Product.Rating,
                        IsActive = x.Product.IsActive,
                        CreatedBy = x.Product.CreatedBy,
                        CreatedOn = x.Product.CreatedOn,
                        UpdatedBy = x.Product.UpdatedBy,
                        UpdatedOn = x.Product.UpdatedOn,
                        ProductDetails = new ProductDetailDto()
                        {
                            ProductDetailId = x.Product.ProductDetail!.ProductDetailId,
                            ProductId = x.Product.ProductDetail.ProductId,
                            Description = x.Product.ProductDetail.Description,
                            IsActive = x.Product.ProductDetail.IsActive,
                            CreatedBy = x.Product.ProductDetail.CreatedBy,
                            CreatedOn = x.Product.ProductDetail.CreatedOn,
                            UpdatedBy = x.Product.ProductDetail.UpdatedBy,
                            UpdatedOn = x.Product.ProductDetail.UpdatedOn
                        }
                    }
                }
            }).ToList();

            return Success();
        }
    }
}
