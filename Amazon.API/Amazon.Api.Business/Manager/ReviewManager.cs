using Amazon.Api.Entities.Messages.Review;
using Amazon.Api.Handlers.Review;

namespace Amazon.Api.Business.Manager
{
    public class ReviewManager(
        GetReviewListHandler _getReviewListHandler,
        GetReviewHandler _getReviewHandler,
        AddReviewHandler _addReviewHandler,
        UpdateReviewHandler _updateReviewHandler,
        DeleteReviewHandler _deleteReviewHandler)
    {
        public async Task<GetReviewListResponse> GetAllAsync()
        {
            var getReviewListRequest = new GetReviewListRequest();

            return await _getReviewListHandler.HandleAsync(getReviewListRequest);
        }

        public async Task<GetReviewResponse> GetByIdAsync(GetReviewRequest getReviewRequest)
        {
            return await _getReviewHandler.HandleAsync(getReviewRequest);
        }

        public async Task<AddReviewResponse> CreateAsync(AddReviewRequest addReviewRequest)
        {
            return await _addReviewHandler.HandleAsync(addReviewRequest);
        }

        public async Task<UpdateReviewResponse> UpdateAsync(UpdateReviewRequest updateReviewRequest)
        {
            return await _updateReviewHandler.HandleAsync(updateReviewRequest);
        }

        public async Task<DeleteReviewResponse> DeleteAsync(DeleteReviewRequest deleteReviewRequest)
        {
            return await _deleteReviewHandler.HandleAsync(deleteReviewRequest);
        }
    }
}
