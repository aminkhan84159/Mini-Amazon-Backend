using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;

namespace Amazon.Api.Services.Service
{
    public class ReviewService : GenericService<Review, ReviewValidator>, IReviewService
    {
        public ReviewService(
            AmazonContext amazonContext,
            ReviewValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
