using Amazon.Api.Business.Manager;
using Amazon.Api.Entities.Messages.Product;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(
        ILogger<ProductController> logger,
        ProductManager productManager)
        : GenericController<GetProductRequest, AddProductRequest, UpdateProductRequest, DeleteProductRequest>(logger, productManager)
    {
        [HttpPost("GetProductsByCartId")]
        public async Task<IActionResult> GetProductsByCartId(GetProductsByCartIdRequest getProductsByCartIdRequest)
        {
            return await GetResponseAsync(async () =>
            {
                var getProductsByCartIdResponse = await productManager.GetProductsByCartId(getProductsByCartIdRequest);

                return Ok(getProductsByCartIdResponse);
            });
        }

        [HttpPost("FilteredProducts")]
        public async Task<IActionResult> GetFilteredProducts([FromBody] GetFilteredProductsRequest getFilteredProductsRequest)
        {
            return await GetResponseAsync(async () =>
            {
                var getFilteredProductsResponse = await productManager.GetFilteredProducts(getFilteredProductsRequest);

                return Ok(getFilteredProductsResponse);
            });
        }

        [HttpPost("GetProductsByCategories")]
        public async Task<IActionResult> GetProductsByCategories([FromBody] GetProductsByCategoriesRequest getProductsByCategoriesRequest)
        {
            return await GetResponseAsync(async () =>
            {
                var getProductsByCategoriesResponse = await productManager.GetProductsByCategories(getProductsByCategoriesRequest);

                return Ok(getProductsByCategoriesResponse);
            });
        }
    }
}
