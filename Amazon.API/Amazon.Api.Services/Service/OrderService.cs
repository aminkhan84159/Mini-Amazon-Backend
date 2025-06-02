using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;

namespace Amazon.Api.Services.Service
{
    public class OrderService : GenericService<Order, OrderValidator>, IOrderService
    {
        public OrderService(
            AmazonContext amazonContext,
            OrderValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
