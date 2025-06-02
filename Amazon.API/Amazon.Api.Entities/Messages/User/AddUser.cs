using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.User
{
    public class AddUserRequest : RequestBase
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNo { get; set; }
    }

    public class AddUserResponse : ResponseBase
    {
        public string token { get; set; }
    }
}
