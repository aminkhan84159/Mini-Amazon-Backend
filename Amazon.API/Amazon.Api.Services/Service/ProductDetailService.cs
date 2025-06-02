using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;

namespace Amazon.Api.Services.Service
{
    public class ProductDetailService : GenericService<ProductDetail, ProductDetailValidator> ,IProductDetailService
    {
        public ProductDetailService(
            AmazonContext amazonContext,
            ProductDetailValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
