using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.User;
using Amazon.Api.Services.Interfaces;
using Amazon.Api.Services.Service;
using Serilog;

namespace Amazon.Api.Handlers.User
{
    public class GetUserHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserDataService _userDataService)
        : HandlerBase<GetUserRequest, GetUserResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var user = await _userDataService.GetByIdAsync(Request.UserId);

            if (user is null)
                return NotFound($"User with ID  {Request.UserId} not found");

            var userDto = new UserDto()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                PhoneNo = user.PhoneNo,
                IsActive = user.IsActive,
                CreatedBy = user.CreatedBy,
                CreatedOn = user.CreatedOn,
                UpdatedBy = user.UpdatedBy,
                UpdatedOn = user.UpdatedOn
            };

            Response.UserDetails = userDto;

            return Success();
        }
    }
}
