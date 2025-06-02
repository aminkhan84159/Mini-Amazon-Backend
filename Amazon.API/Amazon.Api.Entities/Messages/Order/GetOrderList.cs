using Amazon.Api.Core.ServiceFramework.Messages;
using Amazon.Api.Entities.Dtos;

namespace Amazon.Api.Entities.Messages.Order
{
    public class GetOrderListRequest : RequestBase
    {
    }

    public class GetOrderListResponse : ResponseBase
    {
        public List<OrderDto> Orders { get; set; } = null!;
    }
}
