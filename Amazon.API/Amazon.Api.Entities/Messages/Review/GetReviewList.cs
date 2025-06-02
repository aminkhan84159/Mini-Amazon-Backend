using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Review
{
    public class GetReviewListRequest : RequestBase
    {

    }

    public class GetReviewListResponse : ResponseBase
    {
        public List<ReviewDto> Reviews { get; set; } = null!;
    }
}
