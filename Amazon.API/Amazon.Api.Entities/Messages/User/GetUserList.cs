using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.User
{
    public class GetUserListRequest : RequestBase
    {
    }

    public class  GetUserListResponse : ResponseBase
    {
        public List<UserDto> Users { get; set; } = null!;
    }
}
