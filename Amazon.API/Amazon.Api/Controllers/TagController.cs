using Amazon.Api.Business.Manager;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController(
        ILogger<TagController> logger,
        TagManager tagManager)
        : GenericController<GetTagRequest, AddTagRequest, UpdateTagRequest, DeleteTagRequest>(logger, tagManager)
    {
    }
}
