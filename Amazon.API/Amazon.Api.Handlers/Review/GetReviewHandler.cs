using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Review;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.Review
{
    public class GetReviewHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IReviewService _reviewService)
        : HandlerBase<GetReviewRequest, GetReviewResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var review = await _reviewService.GetByIdAsync(Request.ReviewId);

            if (review is null)
                return NotFound($"Review with ID {Request.ReviewId} not found");

            var reviewDetails = new ReviewDto()
            {
                ReviewId = review.ReviewId,
                ProductId = review.ProductId,
                ReviewerEmail = review.ReviewerEmail,
                ReviewerName = review.ReviewerName,
                Rating = review.Rating,
                Comment = review.Comment,
                IsActive = review.IsActive,
                CreatedBy = review.CreatedBy,
                CreatedOn = review.CreatedOn,
                UpdatedBy = review.UpdatedBy,
                UpdatedOn = review.UpdatedOn
            };


            Response.ReviewDetails = reviewDetails;
            return Success();
        }
    }
}
