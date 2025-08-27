using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;

namespace Amazon.Api.Services.Service
{
    public class ConfirmCartService : GenericService<ConfirmCart, ConfirmCartValidator> , IConfirmCartService
    {
        public ConfirmCartService(
            AmazonContext amazonContext,
            ConfirmCartValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
