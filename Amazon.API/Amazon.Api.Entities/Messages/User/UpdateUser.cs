using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.User
{
    public class UpdateUserRequest : RequestBase
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNo { get; set; }
    }

    public class UpdateUserResponse : ResponseBase
    {
        public UserDto UserDetails { get; set; } = null!;
    }
}
