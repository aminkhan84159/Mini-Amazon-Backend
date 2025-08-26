using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Review;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Review
{
    public class UpdateReviewHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IReviewService _reviewService)
        : HandlerBase<UpdateReviewRequest, UpdateReviewResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var review = await _reviewService.GetAll()
                .Where(x => x.ReviewId == Request.ReviewId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (review is null)
                return NotFound($"Review with ID {Request.ReviewId} not found");

            review.Rating = Request.Rating;
            review.Comment = Request.Comment;
            review.UpdatedBy = 101;
            review.UpdatedOn = DateTime.UtcNow;

            await _reviewService.UpdateAsync(review);

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
