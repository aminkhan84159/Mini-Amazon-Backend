using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Tag;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Tag
{
    public class GetTagListHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        ITagService _tagService)
        : HandlerBase<GetTagListRequest, GetTagListResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var tags = await _tagService.GetAll()
                .ToListAsync();

            if (tags is null || tags.Count == 0)
                return NotFound("No tags found");

            var tagList = tags.Select(x => new TagDto()
            {
                TagId = x.TagId,
                ProductId = x.ProductId,
                Tags = x.Tags,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();

            Response.Tags = tagList;
            return Success();
        }
    }
}
