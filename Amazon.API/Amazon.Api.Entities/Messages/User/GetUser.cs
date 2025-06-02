using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.User
{
    public class GetUserRequest : RequestBase
    {
        public int UserId { get; set; }
    }

    public class GetUserResponse : ResponseBase
    {
        public UserDto UserDetails { get; set; } = null!;
    }
}
