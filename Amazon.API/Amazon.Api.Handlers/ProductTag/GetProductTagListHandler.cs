using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.ProductTag;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.ProductTag
{
    public class GetProductTagListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        IProductTagService _productTagService)
        : HandlerBase<GetProductTagListRequest, GetProductTagListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var productTags = await _productTagService.GetAll()
                .ToListAsync();

            if (productTags is null || productTags.Count == 0)
                return NotFound("No product tags found");

            var productTagList = productTags.Select(x => new Entities.Dtos.ProductTagDto()
            {
                ProductTagId = x.ProductTagId,
                ProductId = x.ProductId,
                TagId = x.TagId
            }).ToList();

            return Success();
        }
    }
}
