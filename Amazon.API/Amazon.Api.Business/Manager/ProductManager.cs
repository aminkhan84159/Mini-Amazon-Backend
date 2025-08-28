using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Handlers.Product;

namespace Amazon.Api.Business.Manager
{
    public class ProductManager(
        GetProductListHandler _getProductListHandler,
        GetProductHandler _getProductHandler,
        AddProductHandler _addProductHandler,
        UpdateProductHandler _updateProductHandler,
        DeleteProductHandler _deleteProductHandler,
        GetProductsByCartIdHandler _getProductsByCartIdHandler,
        GetFilteredProductsHandler _getFilteredProductsHandler,
        GetProductsByCategoriesHandler _getProductsByCategoriesHandler,
        GetOrderedProductsByUserIdHandler _getOrderedProductsByUserIdHandler,
        GetProductsFromConfirmCartHandler _getProductsFromConfirmCartHandler)
    {
        public async Task<GetProductListResponse> GetAllAsync()
        {
            var getProductListRequest = new GetProductListRequest();

            return await _getProductListHandler.HandleAsync(getProductListRequest);
        }

        public async Task<GetProductResponse> GetByIdAsync(GetProductRequest getProductRequest)
        {
            return await _getProductHandler.HandleAsync(getProductRequest);
        }

        public async Task<AddProductResponse> CreateAsync(AddProductRequest addProductRequest)
        {
            return await _addProductHandler.HandleAsync(addProductRequest);
        }

        public async Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest updateProductRequest)
        {
            return await _updateProductHandler.HandleAsync(updateProductRequest);
        }

        public async Task<DeleteProductResponse> DeleteAsync(DeleteProductRequest deleteProductRequest)
        {
            return await _deleteProductHandler.HandleAsync(deleteProductRequest);
        }

        public async Task<GetProductsByCartIdResponse> GetProductsByCartId(GetProductsByCartIdRequest getProductsByCartIdRequest)
        {
            return await _getProductsByCartIdHandler.HandleAsync(getProductsByCartIdRequest);
        }

        public async Task<GetFilteredProductsResponse> GetFilteredProducts(GetFilteredProductsRequest getFilteredProductsRequest)
        {
            return await _getFilteredProductsHandler.HandleAsync(getFilteredProductsRequest);
        }

        public async Task<GetProductsByCategoriesResponse> GetProductsByCategories(GetProductsByCategoriesRequest getProductsByCategoriesRequest)
        {
            return await _getProductsByCategoriesHandler.HandleAsync(getProductsByCategoriesRequest);
        }

        public async Task<GetOrderedProductsByUserIdResponse> GetOrderedProductsByUserId(GetOrderedProductsByUserIdRequest getOrderedProductsByUserIdRequest)
        {
            return await _getOrderedProductsByUserIdHandler.HandleAsync(getOrderedProductsByUserIdRequest);
        }

        public async Task<GetProductsFromConfirmCartResponse> GetProductsFromConfirmCart(GetProductsFromConfirmCartRequest getProductsFromConfirmCartRequest)
        {
            return await _getProductsFromConfirmCartHandler.HandleAsync(getProductsFromConfirmCartRequest);
        }
    }
}
