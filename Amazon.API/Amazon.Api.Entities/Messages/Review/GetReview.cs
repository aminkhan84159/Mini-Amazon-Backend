using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Review
{
    public class GetReviewRequest : RequestBase
    {
        public int ReviewId { get; set; }
    }

    public class GetReviewResponse : ResponseBase
    {
        public ReviewDto ReviewDetails { get; set; } = null!;
    }
}
