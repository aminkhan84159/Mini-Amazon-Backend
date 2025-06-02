using Amazon.Api.Business.Manager;
using Amazon.Api.Entities.Messages.ImageType;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageTypeController(
        ILogger<ImageTypeController> logger,
        ImageTypeManager imageTypeManager)
        : GenericController<GetImageTypeRequest, AddImageTypeRequest, UpdateImageTypeRequest, DeleteImageTypeRequest>(logger, imageTypeManager)
    {
    }
}
