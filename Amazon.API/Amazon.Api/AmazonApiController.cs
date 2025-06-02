﻿using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Amazon.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmazonApiController : ControllerBase
    {
        private readonly ILogger _logger;

        public AmazonApiController(ILogger logger)
        {
            _logger = logger;
        }

        protected IActionResult GetResponse(Func<IActionResult> codeToExecute)
        {
            IActionResult response;

            try
            {
                response = codeToExecute.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured: {ex.Message} --- Inner Exception: {ex.InnerException}");

                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("There's been an error processing your request"),
                    ReasonPhrase = "There's been an error processing your request"
                };

                response = BadRequest(resp);
            }

            return response;
        }

        protected async Task<IActionResult> GetResponseAsync(Func<Task<IActionResult>> codeToExecute)
        {
            IActionResult response;

            try
            {
                response = await codeToExecute.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred: {ex.Message} --- Inner exception: {ex.InnerException}");

                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("There's been an error processing your request"),
                    ReasonPhrase = "There's been an error processing your request"
                };

                response = BadRequest(resp);
            }

            return response;
        }
    }
}
