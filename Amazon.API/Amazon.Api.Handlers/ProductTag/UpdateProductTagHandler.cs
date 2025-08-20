using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ProductTag;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.ProductTag
{
    public class UpdateProductTagHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductTagService _productTagService,
        IProductService _productService,
        ITagService _tagService)
        : HandlerBase<UpdateProductTagRequest, UpdateProductTagResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            if (Request.ProductTagId <= 0)
                return BadRequest("Invalid Product Tag ID");

            var productTag = await _productTagService.GetByIdAsync(Request.ProductTagId);

            if (productTag is null)
                return NotFound($"Product Tag with ID {Request.ProductTagId} not found");

            var product = await _productService.GetByIdAsync(Request.ProductId);

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} not found");

            var tag = await _tagService.GetByIdAsync(Request.TagId);

            if (tag is null)
                return NotFound($"Tag with ID {Request.TagId} not found");

            productTag.ProductId = Request.ProductId;
            productTag.TagId = Request.TagId;

            await _productTagService.UpdateAsync(productTag);

            Response.ProductTagId = productTag.ProductTagId;
            return Success();
        }
    }
}
