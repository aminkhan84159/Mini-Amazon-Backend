using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Review;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Review
{
    public class DeleteReviewHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IReviewService _reviewService)
        : HandlerBase<DeleteReviewRequest, DeleteReviewResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var review = await _reviewService.GetAll()
                .Where(x => x.ReviewId == Request.ReviewId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (review is null)
                return NotFound($"Review with ID {Request.ReviewId} not found");

            review.IsActive = false;
            review.UpdatedBy = 101;
            review.UpdatedOn = DateTime.UtcNow;

            await _reviewService.UpdateAsync(review);

            Response.ReviewId = review.ReviewId;
            return Success();
        }
    }
}
