using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.User
{
    public class LoginUserRequest : RequestBase
    {
        public string info { get; set; }

        public string password { get; set; }
    }

    public class LoginUserResponse : ResponseBase
    {
        public string token { get; set; }
    }
}
