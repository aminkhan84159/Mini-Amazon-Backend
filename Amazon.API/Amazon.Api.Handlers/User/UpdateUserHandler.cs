using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.User;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.User
{
    public class UpdateUserHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserDataService _userDataService)
        : HandlerBase<UpdateUserRequest, UpdateUserResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var user = await _userDataService.GetAll()
                .Where(x => x.UserId == Request.UserId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (user is null)
                return NotFound($"User with ID  {Request.UserId} not found");

            var existingUsers = await _userDataService.GetAll()
                .Where(x => x.Email == Request.Email || x.Username == Request.Username || x.PhoneNo == Request.PhoneNo && x.IsActive == true)
                .ToListAsync();

            if (user.Email != Request.Email)
            {
                if (existingUsers is not null)
                {
                    if (existingUsers.FirstOrDefault(x => x.Email == Request.Email) is not null)
                        return Conflict($"Email {Request.Email} already exists");
                }
            }

            if (user.Username != Request.Username)
            {
                if (existingUsers is not null)
                {
                    if (existingUsers.FirstOrDefault(x => x.Username == Request.Username) is not null)
                        return Conflict($"Username {Request.Username} already exists");
                }
            }

            if (user.PhoneNo != Request.PhoneNo)
            {
                if (existingUsers is not null)
                {
                    if (existingUsers.FirstOrDefault(x => x.PhoneNo == Request.PhoneNo) is not null)
                        return Conflict($"Phone number {Request.PhoneNo} already exists");
                }
            }

            user.FirstName = Request.FirstName;
            user.LastName = Request.LastName;
            user.Email = Request.Email;
            user.Username = Request.Username;
            user.Password = Request.Password;
            user.PhoneNo = Request.PhoneNo;
            user.UpdatedBy = Request.UserId;
            user.UpdatedOn = DateTime.UtcNow;

            await _userDataService.UpdateAsync(user);

            var userDetails = new UserDto()
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

            Response.UserDetails = userDetails;

            return Success();
        }
    }
}
