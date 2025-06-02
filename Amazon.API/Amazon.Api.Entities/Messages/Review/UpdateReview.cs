using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Review
{
    public class UpdateReviewRequest : RequestBase
    {
        public int ReviewId { get; set; }
        public string? Comment { get; set; }
        public decimal Rating { get; set; }
    }

    public class UpdateReviewResponse : ResponseBase
    {
        public ReviewDto ReviewDetails { get; set; } = null!;
    }
}
