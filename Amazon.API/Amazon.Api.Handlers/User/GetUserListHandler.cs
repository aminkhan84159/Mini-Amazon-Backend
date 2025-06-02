using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.User;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.User
{
    public class GetUserListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IUserDataService _userDataService)
        : HandlerBase<GetUserListRequest, GetUserListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var users = await _userDataService.GetAll()
                .ToListAsync();

            if (users is null || users.Count == 0)
                return NotFound("No visitors found");

            var userDtoList = users.Select(x => new UserDto()
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Username = x.Username,
                Password = x.Password,
                PhoneNo = x.PhoneNo,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();

            Response.Users = userDtoList;

            return Success();
        }
    }
}
