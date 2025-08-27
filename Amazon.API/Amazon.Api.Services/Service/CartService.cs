using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Api.Services.Service
{
    public class CartService : GenericService<Cart, CartValidator>, ICartService
    {
        public CartService(
            AmazonContext amazonContext,
            CartValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
        }
    }
}
