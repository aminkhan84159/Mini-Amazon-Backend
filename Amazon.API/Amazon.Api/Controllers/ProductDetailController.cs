using Amazon.Api.Business.Manager;
using Amazon.Api.Entities.Messages.ProductDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController(
        ILogger<ProductDetailController> logger,
        ProductDetailManager productDetailManager)
        : GenericController<GetProductDetailRequest, AddProductDetailRequest, UpdateProductDetailRequest, DeleteProductDetailRequest>(logger, productDetailManager)
    {
        [AllowAnonymous]
        [HttpPost("GetProductDetailsByProductId")]
        public async Task<IActionResult> GetProductDetailsByProductIdAsync([FromBody] GetProductDetailsByProductIdRequest getProductDetailsByProductIdRequest)
        {
            return await GetResponseAsync(async () =>
            {
                var result = await productDetailManager.GetProductDetailsByProductId(getProductDetailsByProductIdRequest);

                return Ok(result);
            });
        }
    }
}
