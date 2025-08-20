using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ProductTag;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ProductTag
{
    public class AddProductTagHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductTagService _productTagService,
        IProductService _productService,
        ITagService _tagService)
        : HandlerBase<AddProductTagRequest, AddProductTagResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var product = await _productService.GetByIdAsync(Request.ProductId);

            if (product is null)
                return NotFound($"Product with ID {Request.ProductId} not found");

            var tag = await _tagService.GetByIdAsync(Request.TagId);

            if (tag is null)
                return NotFound($"Tag with ID {Request.TagId} not found");

            var existingProductTag = await _productTagService.GetAll()
                .Where(x => x.ProductId == Request.ProductId && x.TagId == Request.TagId)
                .FirstOrDefaultAsync();

            if (existingProductTag is not null)
                return Conflict($"Product with ID {Request.ProductId} already has tag with ID {Request.TagId}");

            var productTag = new Data.Entities.ProductTag
            {
                ProductId = Request.ProductId,
                TagId = Request.TagId,
            };

            await _productTagService.AddAsync(productTag);

            Response.ProductTagId = productTag.ProductTagId;
            return Success();
        }
    }
}
