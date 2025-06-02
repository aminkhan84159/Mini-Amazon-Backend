using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Review;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.Review
{
    public class AddReviewHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IReviewService _reviewService,
        IProductService _productService)
        : HandlerBase<AddReviewRequest, AddReviewResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetByIdAsync(Request.ProductId);

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} not found");

            var review = new Data.Entities.Review()
            {
                ProductId = Request.ProductId,
                ReviewerEmail = Request.ReviewerEmail,
                ReviewerName = Request.ReviewerName,
                Comment = Request.Comment,
                Rating = Request.Rating,
                CreatedBy = 101,
                CreatedOn = DateTime.UtcNow
            };

            await _reviewService.AddAsync(review);

            Response.ReviewId = review.ReviewId;
            return Success();
        }
    }
}
