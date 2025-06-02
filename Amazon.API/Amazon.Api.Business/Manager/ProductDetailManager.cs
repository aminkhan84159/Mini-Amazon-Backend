using Amazon.Api.Entities.Messages.Product;
using Amazon.Api.Entities.Messages.ProductDetail;
using Amazon.Api.Handlers.Product;
using Amazon.Api.Handlers.ProductDetail;

namespace Amazon.Api.Business.Manager
{
    public class ProductDetailManager(
        GetProductDetailListHandler _getAllProductDetailHandler,
        GetProductDetailHandler _getProductDetailHandler,
        AddProductDetailHandler _addProductDetailHandler,
        UpdateProductDetailHandler _updateProductDetailHandler,
        DeleteProductDetailHandler _deleteProductDetailHandler,
        GetProductDetailsByProductIdHandler _getProductDetailsByProductIdHandler)
    {
        public async Task<GetProductDetailListResponse> GetAllAsync()
        {
            var getProductDetailListRequest = new GetProductDetailListRequest();

            return await _getAllProductDetailHandler.HandleAsync(getProductDetailListRequest);
        }

        public async Task<GetProductDetailResponse> GetByIdAsync(GetProductDetailRequest getProductDetailRequest)
        {
            return await _getProductDetailHandler.HandleAsync(getProductDetailRequest);
        }

        public async Task<AddProductDetailResponse> CreateAsync(AddProductDetailRequest addProductDetailRequest)
        {
            return await _addProductDetailHandler.HandleAsync(addProductDetailRequest);
        }

        public async Task<UpdateProductDetailResponse> UpdateAsync(UpdateProductDetailRequest updateProductDetailRequest)
        {
            return await _updateProductDetailHandler.HandleAsync(updateProductDetailRequest);
        }

        public async Task<DeleteProductDetailResponse> DeleteAsync(DeleteProductDetailRequest deleteProductDetailRequest)
        {
            return await _deleteProductDetailHandler.HandleAsync(deleteProductDetailRequest);
        }

        public async Task<GetProductDetailsByProductIdResponse> GetProductDetailsByProductId(GetProductDetailsByProductIdRequest getProductDetailsByProductIdRequest)
        {
            return await _getProductDetailsByProductIdHandler.HandleAsync(getProductDetailsByProductIdRequest);
        }
    }
}
