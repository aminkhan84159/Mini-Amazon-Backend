using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;

namespace Amazon.Api.Services.Service
{
    public class UserCartService : GenericService<UserCart, UserCartValidator> , IUserCartService
    {
        public UserCartService(
            AmazonContext amazonContext,
            UserCartValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
