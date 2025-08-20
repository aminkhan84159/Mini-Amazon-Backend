using Amazon.Api.Business.Manager;
using Amazon.Api.Entities.Messages.ProductTag;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTagController(
        ILogger<ProductTagController> logger,
        ProductTagManager productTagManager)
        : GenericController<GetProductTagRequest, AddProductTagRequest, UpdateProductTagRequest, DeleteProductTagRequest>(logger, productTagManager)
    {
    }
}
