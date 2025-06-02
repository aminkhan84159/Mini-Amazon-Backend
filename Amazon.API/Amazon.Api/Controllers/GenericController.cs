using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController<T, U, Z, V>(
        ILogger<GenericController<T, U, Z, V>> logger,
        object _manager) : AmazonApiController(logger)
        where T : class
        where U : class
        where Z : class
        where V : class
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return await GetResponseAsync(async () =>
            {
                dynamic manager = _manager;
                var result = await manager.GetAllAsync();

                return Ok(result);
            });
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromBody] T request)
        {
            return await GetResponseAsync(async () =>
            {
                dynamic manager = _manager;
                var result = await manager.GetByIdAsync(request);

                return Ok(result);
            });
        }

        [AllowAnonymous]
        [HttpPost("Add")]
        public async Task<IActionResult> CreateAsync([FromBody] U entity)
        {
            return await GetResponseAsync(async () =>
            {
                dynamic manager = _manager;

                var createResponse = await manager.CreateAsync(entity);

                return Ok(createResponse);
            });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Z entity)
        {
            return await GetResponseAsync(async () =>
            {
                dynamic manager = _manager;

                var createResponse = await manager.UpdateAsync(entity);

                return Ok(createResponse);
            });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] V entity)
        {
            return await GetResponseAsync(async () =>
            {
                dynamic manager = _manager;
                var response = await manager.DeleteAsync(entity);

                return Ok(response);
            });
        }
    }
}
