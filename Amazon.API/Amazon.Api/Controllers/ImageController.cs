using Amazon.Api.Business.Manager;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Image;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController(
        ILogger<ImageController> logger,
        ImageManager imageManager)
        : GenericController<GetImageRequest, AddImageRequest, UpdateImageRequest, DeleteImageRequest>(logger, imageManager)
    {
        //[HttpPost("image")]
        //[Consumes("multipart/form-data")]
        //public async Task<IActionResult> CreateAsync(AddImageRequest addImageRequests)
        //{
        //    return await GetResponseAsync(async () =>
        //    {
        //        var files = this.HttpContext.Request.Form.Files;

        //        if (files.Count == 0)
        //            throw new ArgumentException();
        //        else
        //        {
        //            var addImageRequest = new List<AddImageRequest>();

        //            foreach (var formFile in files)
        //            {
        //                if (formFile.Length > 0)
        //                {
        //                    using (var stream = new System.IO.MemoryStream())
        //                    {
        //                        await formFile.CopyToAsync(stream);

        //                        var item = new AddImageRequest
        //                        {
        //                            ImageTypeId = addImageRequests.ImageTypeId,
        //                            ProductId = addImageRequests.ProductId,
        //                            Images = stream.ToArray()
        //                        };

        //                        addImageRequest.Add(item);
        //                        imageManager.CreateAsync(item);
        //                    }
        //                }
        //            }
        //        }

        //        return Ok(files);
        //    });
        //}

        [HttpPost("AddImage")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateAsync([FromForm] AddImageRequest entity)
        {
            return await GetResponseAsync(async () =>
            {
                var createResponse = await imageManager.CreateAsync(entity);

                return Ok(createResponse);
            });
        }

        [HttpPost("GetImagesByProductId")]
        public async Task<IActionResult> GetImagesByProductId(GetImagesByProductIdRequest getImagesByProductIdRequest)
        {
            return await GetResponseAsync(async () =>
            {
                var getImagesByProductIdResponse = await imageManager.GetImagesByProductId(getImagesByProductIdRequest);

                return Ok(getImagesByProductIdResponse);
            });
        }
    }
}
