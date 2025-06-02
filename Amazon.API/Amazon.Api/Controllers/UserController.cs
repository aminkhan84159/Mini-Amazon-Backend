using Amazon.Api.Business.Manager;
using Amazon.Api.Entities.Messages.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
        (ILogger<UserController> logger,
        UserManager userManager)
        : GenericController<GetUserRequest, AddUserRequest, UpdateUserRequest, DeleteUserRequest>(logger, userManager)
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginUserRequest loginUserRequest)
        {
            return await GetResponseAsync(async () =>
            {
                var loginUserResponse = await userManager.LoginUser(loginUserRequest);

                return Ok(loginUserResponse);
            });
        }
    }
}
