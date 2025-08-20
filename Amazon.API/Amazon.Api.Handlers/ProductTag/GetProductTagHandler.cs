using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ProductTag;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.ProductTag
{
    public class GetProductTagHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductTagService _productTagService)
        : HandlerBase<GetProductTagRequest, GetProductTagResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            if (Request.ProductTagId <= 0)
                return BadRequest("ProductTagId must be greater than zero");

            var productTag = await _productTagService.GetByIdAsync(Request.ProductTagId);

            if (productTag is null)
                return NotFound($"Product tag with ID {Request.ProductTagId} not found");

            var productTagDetails = new Entities.Dtos.ProductTagDto
            {
                ProductTagId = productTag.ProductTagId,
                ProductId = productTag.ProductId,
                TagId = productTag.TagId,
            };

            Response.ProductTagDetails = productTagDetails;
            return Success();
        }
    }
}
