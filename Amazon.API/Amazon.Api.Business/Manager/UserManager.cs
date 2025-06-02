using Amazon.Api.Entities.Messages.User;
using Amazon.Api.Handlers.User;

namespace Amazon.Api.Business.Manager
{
    public class UserManager(
        GetUserListHandler _getUserListHandler,
        GetUserHandler _getUserHandler,
        AddUserHandler _addUserHandler,
        UpdateUserHandler _updateUserHandler,
        DeleteUserHandler _deleteUserHandler,
        LoginUserHandler _loginUserHandler)
    {

        public async Task<GetUserListResponse> GetAllAsync()
        {
            var getUserListRequest = new GetUserListRequest();

            return await _getUserListHandler.HandleAsync(getUserListRequest);
        }

        public async Task<GetUserResponse> GetByIdAsync(GetUserRequest getUserRequest)
        {
            return await _getUserHandler.HandleAsync(getUserRequest);
        }

        public async Task<AddUserResponse> CreateAsync(AddUserRequest addUserRequest)
        {
            return await _addUserHandler.HandleAsync(addUserRequest);
        }

        public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            return await _updateUserHandler.HandleAsync(updateUserRequest);
        }

        public async Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest deleteUserRequest)
        {
            return await _deleteUserHandler.HandleAsync(deleteUserRequest);
        }

        public async Task<LoginUserResponse> LoginUser(LoginUserRequest loginUserRequest)
        {
            return await _loginUserHandler.HandleAsync(loginUserRequest);
        }
    }
}
