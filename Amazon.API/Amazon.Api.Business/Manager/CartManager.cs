using Amazon.Api.Entities.Messages.Cart;
using Amazon.Api.Handlers.Cart;
using Amazon.Api.Handlers.User;

namespace Amazon.Api.Business.Manager
{
    public class CartManager(
        GetCartListHandler _getCartListHandler,
        GetCartHandler _getCartHandler,
        AddCartHandler _addCartHandler,
        UpdateCartHandler _updateCartHandler,
        DeleteCartHandler _deleteCartHandler)
    {
        public async Task<GetCartListResponse> GetAllAsync()
        {
            var getCartListRequest = new GetCartListRequest();

            return await _getCartListHandler.HandleAsync(getCartListRequest);
        }

        public async Task<GetCartResponse> GetByIdAsync(GetCartRequest getCartRequest)
        {
            return await _getCartHandler.HandleAsync(getCartRequest);
        }

        public async Task<AddCartResponse> CreateAsync(AddCartRequest addCartRequest)
        {
            return await _addCartHandler.HandleAsync(addCartRequest);
        }

        public async Task<UpdateCartResponse> UpdateAsync(UpdateCartRequest updateCartRequest)
        {
            return await _updateCartHandler.HandleAsync(updateCartRequest);
        }

        public async Task<DeleteCartResponse> DeleteAsync(DeleteCartRequest deleteCartRequest)
        {
            return await _deleteCartHandler.HandleAsync(deleteCartRequest);
        }
    }
}
