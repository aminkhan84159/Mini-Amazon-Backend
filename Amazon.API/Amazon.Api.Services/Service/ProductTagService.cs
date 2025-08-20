using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;

namespace Amazon.Api.Services.Service
{
    public class ProductTagService : GenericService<ProductTag, ProductTagValidator> , IProductTagService
    {
        public ProductTagService(
            AmazonContext amazonContext,
            ProductTagValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
