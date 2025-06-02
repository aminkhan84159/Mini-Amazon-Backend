using Amazon.Api.Entities.Messages.Image;
using Amazon.Api.Handlers.Image;
using System.Formats.Asn1;
using System.Runtime.CompilerServices;

namespace Amazon.Api.Business.Manager
{
    public class ImageManager(
        GetImageListHandler _getAllImageHandler,
        GetImageHandler _getImageHandler,
        AddImageHandler _addImageHandler,
        UpdateImageHandler _updateImageHandler,
        DeleteImageHandler _deleteImageHandler,
        GetImagesByProductIdHandler _getImagesByProductIdHandler)
    {
        public async Task<GetImageListResponse> GetAllAsync()
        {
            var getImageListRequest = new GetImageListRequest();

            return await _getAllImageHandler.HandleAsync(getImageListRequest);
        }

        public async Task<GetImageResponse> GetByIdAsync(GetImageRequest getImageRequest)
        {
            return await _getImageHandler.HandleAsync(getImageRequest);
        }

        public async Task<AddImageResponse> CreateAsync(AddImageRequest addImageRequest)
        {
            return await _addImageHandler.HandleAsync(addImageRequest);
        }

        public async Task<UpdateImageResponse> UpdateAsync(UpdateImageRequest updateImageRequest)
        {
            return await _updateImageHandler.HandleAsync(updateImageRequest);
        }

        public async Task<DeleteImageResponse> DeleteAsync(DeleteImageRequest deleteImageRequest)
        {
            return await _deleteImageHandler.HandleAsync(deleteImageRequest);
        }

        public async Task<GetImagesByProductIdResponse> GetImagesByProductId(GetImagesByProductIdRequest getImagesByProductIdRequest)
        {
            return await _getImagesByProductIdHandler.HandleAsync(getImagesByProductIdRequest);
        }
    }
}
