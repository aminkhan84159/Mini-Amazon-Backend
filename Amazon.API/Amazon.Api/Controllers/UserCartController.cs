using Amazon.Api.Business.Manager;
using Amazon.Api.Entities.Messages.UserCart;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCartController(
        ILogger<UserCartController> logger,
        UserCartManager userCartManager)
        : GenericController<GetUserCartRequest, AddUserCartRequest, UpdateUserCartRequest, DeleteUserCartRequest>(logger, userCartManager)
    {
    }
}
