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
        IOrderService _orderService,
        IUserDataService _userService)
        : HandlerBase<GetOrderedProductsByUserIdRequest,  GetOrderedProductsByUserIdResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var user = await _userService.GetByIdAsync(Request.UserId);

            if (user is null)
                return NotFound($"User with ID  {Request.UserId} not found");

            var orders = await _orderService.GetAll()
                .Include(x => x.Product)
                .Where(x => x.UserId == Request.UserId && x.IsActive == true)
                .ToListAsync();

            if (orders is null || orders.Count == 0)
                return NotFound("No Orders found");

            var orderList = orders.Select(x => new OrderDto()
            {
                OrderId = x.OrderId,
                UserId = x.UserId,
                ProductId = x.ProductId,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn,
                Products = new ProductDto()
                {
                    ProductId = x.Product.ProductId,
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
                        Description = x.Product.ProductDetail.Description
                    }
                }
            }).ToList();

            return Success();
        }
    }
}
