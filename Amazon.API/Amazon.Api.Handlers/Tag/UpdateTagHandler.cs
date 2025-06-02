using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Dtos;
using Amazon.Api.Entities.Messages.Tag;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Handlers.Tag
{
    public class UpdateTagHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        ITagService _tagService)
        : HandlerBase<UpdateTagRequest, UpdateTagResponse>(_logger, _amazonContext)
    {
        protected override async Task<bool> HandleCoreAsync()
        {
            var tag = await _tagService.GetByIdAsync(Request.TagId);

            if (tag is null)
                return NotFound($"Tag with ID {Request.TagId} not found");

            tag.Tags = Request.Tags;
            tag.UpdatedBy = 101;
            tag.UpdatedOn = DateTime.UtcNow;

            await _tagService.UpdateAsync(tag);

            var tagDetails = new TagDto()
            {
                TagId = tag.TagId,
                ProductId = tag.ProductId,
                Tags = tag.Tags,
                IsActive = tag.IsActive,
                CreatedBy = tag.CreatedBy,
                CreatedOn = tag.CreatedOn,
                UpdatedBy = tag.UpdatedBy,
                UpdatedOn = tag.UpdatedOn
            };

            Response.TagDetails = tagDetails;
            return Success();
        }
    }
}
