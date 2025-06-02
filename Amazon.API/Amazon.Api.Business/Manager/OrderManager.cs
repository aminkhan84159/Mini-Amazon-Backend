using Amazon.Api.Entities.Messages.Order;
using Amazon.Api.Handlers.Order;

namespace Amazon.Api.Business.Manager
{
    public class OrderManager(
        GetOrderListHandler _getOrderListHandler,
        GetOrderHandler _getOrderHandler,
        AddOrderHandler _addOrderHandler,
        UpdateOrderHandler _updateOrderHandler,
        DeleteOrderHandler _deleteOrderHandler)
    {
        public async Task<GetOrderListResponse> GetAllAsync()
        {
            var getOrderListRequest = new GetOrderListRequest();

            return await _getOrderListHandler.HandleAsync(getOrderListRequest);
        }

        public async Task<GetOrderResponse> GetByIdAsync(GetOrderRequest getOrderRequest)
        {
            return await _getOrderHandler.HandleAsync(getOrderRequest);
        }

        public async Task<AddOrderResponse> CreateAsync(AddOrderRequest addOrderRequest)
        {
            return await _addOrderHandler.HandleAsync(addOrderRequest);
        }

        public async Task<UpdateOrderResponse> UpdateAsync(UpdateOrderRequest updateOrderRequest)
        {
            return await _updateOrderHandler.HandleAsync(updateOrderRequest);
        }

        public async Task<DeleteOrderResponse> DeleteAsync(DeleteOrderRequest deleteOrderRequest)
        {
            return await _deleteOrderHandler.HandleAsync(deleteOrderRequest);
        }
    }
}
