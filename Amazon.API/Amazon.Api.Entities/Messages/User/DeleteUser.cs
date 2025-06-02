using Amazon.Api.Core.ServiceFramework.Messages;

namespace Amazon.Api.Entities.Messages.User
{
    public class DeleteUserRequest : RequestBase
    {
        public int UserId { get; set; }
    }

    public class DeleteUserResponse : ResponseBase
    {
        public int UserId { get; set; }
    }
}
