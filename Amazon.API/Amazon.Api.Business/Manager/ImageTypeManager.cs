using Amazon.Api.Entities.Messages.Image;
using Amazon.Api.Entities.Messages.ImageType;
using Amazon.Api.Handlers.Image;
using Amazon.Api.Handlers.ImageType;

namespace Amazon.Api.Business.Manager
{
    public class ImageTypeManager(
        GetImageTypeListHandler _getImageTypeListHandler,
        GetImageTypeHandler _getImageTypeHandler,
        AddImageTypeHandler _addImageTypeHandler,
        UpdateImageTypeHandler _updateImageTypeHandler,
        DeleteImageTypeHandler _deleteImageTypeHandler)
    {
        public async Task<GetImageTypeListResponse> GetAllAsync()
        {
            var getImageTypeListRequest = new GetImageTypeListRequest();

            return await _getImageTypeListHandler.HandleAsync(getImageTypeListRequest);
        }

        public async Task<GetImageTypeResponse> GetByIdAsync(GetImageTypeRequest getImageTypeRequest)
        {
            return await _getImageTypeHandler.HandleAsync(getImageTypeRequest);
        }

        public async Task<AddImageTypeResponse> CreateAsync(AddImageTypeRequest addImageTypeRequest)
        {
            return await _addImageTypeHandler.HandleAsync(addImageTypeRequest);
        }

        public async Task<UpdateImageTypeResponse> UpdateAsync(UpdateImageTypeRequest updateImageTypeRequest)
        {
            return await _updateImageTypeHandler.HandleAsync(updateImageTypeRequest);
        }

        public async Task<DeleteImageTypeResponse> DeleteAsync(DeleteImageTypeRequest deleteImageTypeRequest)
        {
            return await _deleteImageTypeHandler.HandleAsync(deleteImageTypeRequest);
        }
    }
}
