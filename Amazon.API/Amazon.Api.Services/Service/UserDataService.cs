using Amazon.Api.Core.Interfaces;
using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Api.Services.Service
{
    public class UserDataService : GenericService<User, UserValidator>, IUserDataService
    {

        public UserDataService(
            AmazonContext amazonContext,
            UserValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
        }
    }
}
