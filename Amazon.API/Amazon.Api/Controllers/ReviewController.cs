using Amazon.Api.Business.Manager;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Review;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(
        ILogger<ReviewController> logger,
        ReviewManager reviewManager)
        : GenericController<GetReviewRequest, AddReviewRequest, UpdateReviewRequest, DeleteReviewRequest>(logger, reviewManager)
    {
    }
}
