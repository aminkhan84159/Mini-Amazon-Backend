using Amazon.Api.Entities.Messages.UserCart;
using Amazon.Api.Handlers.Product;
using Amazon.Api.Handlers.UserCart;

namespace Amazon.Api.Business.Manager
{
    public class UserCartManager(
        GetUserCartListHandler _getUserCartListHandler,
        GetUserCartHandler _getUserCartHandler,
        AddUserCartHandler _addUserCartHandler,
        UpdateUserCartHandler _updateUserCartHandler,
        DeleteUserCartHandler _deleteUserCartHandler)
    {
        public async Task<GetUserCartListResponse> GetAllAsync()
        {
            var getUserCartListRequest = new GetUserCartListRequest();

            return await _getUserCartListHandler.HandleAsync(getUserCartListRequest);
        }

        public async Task<GetUserCartResponse> GetByIdAsync(GetUserCartRequest getUserCartRequest)
        {
            return await _getUserCartHandler.HandleAsync(getUserCartRequest);
        }

        public async Task<AddUserCartResponse> CreateAsync(AddUserCartRequest addUserCartRequest)
        {
            return await _addUserCartHandler.HandleAsync(addUserCartRequest);
        }

        public async Task<UpdateUserCartResponse> UpdateAsync(UpdateUserCartRequest updateUserCartRequest)
        {
            return await _updateUserCartHandler.HandleAsync(updateUserCartRequest);
        }

        public async Task<DeleteUserCartResponse> DeleteAsync(DeleteUserCartRequest deleteUserCartRequest)
        {
            return await _deleteUserCartHandler.HandleAsync(deleteUserCartRequest);
        }
    }
}
