using Amazon.Api.Business.Manager;
using Amazon.Api.Entities.Messages.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(
        ILogger<CartController> logger,
        CartManager cartManager)
        : GenericController<GetCartRequest, AddCartRequest, UpdateCartRequest, DeleteCartRequest>(logger, cartManager)
    {
    }
}
