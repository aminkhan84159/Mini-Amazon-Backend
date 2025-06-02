using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;

namespace Amazon.Api.Services.Service
{
    public class ProductService : GenericService<Product, ProductValidator> , IProductService
    {
        public ProductService(
            AmazonContext amazonContext,
            ProductValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
