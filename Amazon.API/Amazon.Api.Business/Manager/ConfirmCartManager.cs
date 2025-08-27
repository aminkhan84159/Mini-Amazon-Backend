using Amazon.Api.Entities.Messages.ConfirmCart;
using Amazon.Api.Handlers.ConfirmCart;

namespace Amazon.Api.Business.Manager
{
    public class ConfirmCartManager(
        GetConfirmCartListHandler _getConfirmCartListHandler,
        GetConfirmCartHandler _getConfirmCartHandler,
        AddConfirmCartHandler _addConfirmCartHandler,
        UpdateConfirmCartHandler _updateConfirmCartHandler,
        DeleteConfirmCartHandler _deleteConfirmCartHandler)
    {
        public async Task<GetConfirmCartListResponse> GetAllAsync()
        {
            var getConfirmCartListRequest = new GetConfirmCartListRequest();

            return await _getConfirmCartListHandler.HandleAsync(getConfirmCartListRequest);
        }

        public async Task<GetConfirmCartResponse> GetByIdAsync(GetConfirmCartRequest getConfirmCartRequest)
        {
            return await _getConfirmCartHandler.HandleAsync(getConfirmCartRequest);
        }

        public async Task<AddConfirmCartResponse> CreateAsync(AddConfirmCartRequest addConfirmCartRequest)
        {
            return await _addConfirmCartHandler.HandleAsync(addConfirmCartRequest);
        }

        public async Task<UpdateConfirmCartResponse> UpdateAsync(UpdateConfirmCartRequest updateConfirmCartRequest)
        {
            return await _updateConfirmCartHandler.HandleAsync(updateConfirmCartRequest);
        }

        public async Task<DeleteConfirmCartResponse> DeleteAsync(DeleteConfirmCartRequest deleteConfirmCartRequest)
        {
            return await _deleteConfirmCartHandler.HandleAsync(deleteConfirmCartRequest);
        }
    }
}
