using Amazon.Api.Entities.Messages.ProductTag;
using Amazon.Api.Entities.Messages.Tag;
using Amazon.Api.Handlers.ProductTag;
using Amazon.Api.Handlers.Tag;

namespace Amazon.Api.Business.Manager
{
    public class ProductTagManager(
        GetProductTagListHandler _getProductTagListHandler,
        GetProductTagHandler _getProductTagHandler,
        AddProductTagHandler _addProductTagHandler,
        UpdateProductTagHandler _updateProductTagHandler,
        DeleteProductTagHandler _deleteProductTagHandler)
    {
        public async Task<GetProductTagListResponse> GetAllAsync()
        {
            var getProductTagListRequest = new GetProductTagListRequest();

            return await _getProductTagListHandler.HandleAsync(getProductTagListRequest);
        }

        public async Task<GetProductTagResponse> GetByIdAsync(GetProductTagRequest getProductTagRequest)
        {
            return await _getProductTagHandler.HandleAsync(getProductTagRequest);
        }

        public async Task<AddProductTagResponse> CreateAsync(AddProductTagRequest addProductTagRequest)
        {
            return await _addProductTagHandler.HandleAsync(addProductTagRequest);
        }

        public async Task<UpdateProductTagResponse> UpdateAsync(UpdateProductTagRequest updateProductTagRequest)
        {
            return await _updateProductTagHandler.HandleAsync(updateProductTagRequest);
        }

        public async Task<DeleteProductTagResponse> DeleteAsync(DeleteProductTagRequest deleteProductTagRequest)
        {
            return await _deleteProductTagHandler.HandleAsync(deleteProductTagRequest);
        }
    }
}
