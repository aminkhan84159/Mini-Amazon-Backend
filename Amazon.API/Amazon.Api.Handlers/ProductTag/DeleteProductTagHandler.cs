using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ProductTag;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ProductTag
{
    public class DeleteProductTagHandler (
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductTagService _productTagService)
        : HandlerBase<DeleteProductTagRequest, DeleteProductTagResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            if (Request.ProductTagId <= 0)
                return BadRequest("Invalid ProductTagId");

            var productTag = await _productTagService.GetAll()
                .Where(x => x.ProductTagId == Request.ProductTagId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (productTag is null)
                return NotFound($"Product tag with ID {Request.ProductTagId} not found");

            productTag.IsActive = false;

            await _productTagService.UpdateAsync(productTag);

            Response.ProductTagId = productTag.ProductTagId;
            return Success();
        }
    }
}
