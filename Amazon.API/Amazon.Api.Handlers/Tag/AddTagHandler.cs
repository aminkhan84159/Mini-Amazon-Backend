using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Tag;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Tag
{
    public class AddTagHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        ITagService _tagDataService)
        : HandlerBase<AddTagRequest, AddTagResponse>(_logger, _amazonContext)
    {
        protected async override Task<bool> HandleCoreAsync()
        {
            if (string.IsNullOrWhiteSpace(Request.Tags))
                return BadRequest("Tag cannot be empty");

            var existingTag = await _tagDataService.GetAll()
                .Where(x => x.Tags == Request.Tags)
                .FirstOrDefaultAsync();

            if (existingTag is not null)
                return Conflict($"Tag '{Request.Tags}' already exists");

            var tag = new Data.Entities.Tag()
            {
                Tags = Request.Tags,
                CreatedBy = 101,
                CreatedOn = DateTime.UtcNow,
            };

            await _tagDataService.AddAsync(tag);

            Response.TagId = tag.TagId;
            return Success();
        }
    }
}
