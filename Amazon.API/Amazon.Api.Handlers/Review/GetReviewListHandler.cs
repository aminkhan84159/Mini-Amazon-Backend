using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Review;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Review
{
    public class GetReviewListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IReviewService _reviewService)
        : HandlerBase<GetReviewListRequest, GetReviewListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var reviews = await _reviewService.GetAll()
                .ToListAsync();

            if (reviews is null || reviews.Count == 0)
                return NotFound("No reviews found");

            var reviewList = reviews.Select(x => new ReviewDto()
            {
                ReviewId = x.ReviewId,
                ProductId = x.ProductId,
                ReviewerEmail = x.ReviewerEmail,
                ReviewerName = x.ReviewerName,
                Comment = x.Comment,
                Rating = x.Rating,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();


            Response.Reviews = reviewList;
            return Success();
        }
    }
}
