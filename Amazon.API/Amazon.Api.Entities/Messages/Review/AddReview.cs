using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.Review
{
    public class AddReviewRequest : RequestBase
    {
        public int ProductId { get; set; }
        public string ReviewerName { get; set; } = null!;
        public string ReviewerEmail { get; set; } = null!;
        public string? Comment { get; set; }
        public decimal Rating { get; set; }
    }

    public class AddReviewResponse : ResponseBase
    {
        public int ReviewId { get; set; }
    }
}
