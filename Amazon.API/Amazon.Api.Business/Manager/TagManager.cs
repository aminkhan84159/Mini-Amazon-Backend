using Amazon.Api.Entities.Messages.Tag;
using Amazon.Api.Handlers.Tag;

namespace Amazon.Api.Business.Manager
{
    public class TagManager(
        GetTagListHandler _getTagListHandler,
        GetTagHandler _getTagHandler,
        AddTagHandler _addTagHandler,
        UpdateTagHandler _updateTagHandler,
        DeleteTagHandler _deleteTagHandler)
    {
        public async Task<GetTagListResponse> GetAllAsync()
        {
            var getTagListRequest = new GetTagListRequest();

            return await _getTagListHandler.HandleAsync(getTagListRequest);
        }

        public async Task<GetTagResponse> GetByIdAsync(GetTagRequest getTagRequest)
        {
            return await _getTagHandler.HandleAsync(getTagRequest);
        }

        public async Task<AddTagResponse> CreateAsync(AddTagRequest addTagRequest)
        {
            return await _addTagHandler.HandleAsync(addTagRequest);
        }

        public async Task<UpdateTagResponse> UpdateAsync(UpdateTagRequest updateTagRequest)
        {
            return await _updateTagHandler.HandleAsync(updateTagRequest);
        }

        public async Task<DeleteTagResponse> DeleteAsync(DeleteTagRequest deleteTagRequest)
        {
            return await _deleteTagHandler.HandleAsync(deleteTagRequest);
        }
    }
}
