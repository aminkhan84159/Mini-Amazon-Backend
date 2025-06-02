using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Review
{
    public class DeleteReviewRequest : RequestBase
    {
        public int ReviewId { get; set; }
    }

    public class DeleteReviewResponse : ResponseBase
    {
        public int ReviewId { get; set; }
    }
}
