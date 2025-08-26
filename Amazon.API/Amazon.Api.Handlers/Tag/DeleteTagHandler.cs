using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Tag;
using Amazon.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Amazon.Api.Handlers.Tag
{
    public class DeleteTagHandler(
        ILogger _logger,
        AmazonContext _amazonContext,
        ITagService _tagDataService)
        : HandlerBase<DeleteTagRequest, DeleteTagResponse>(_logger, _amazonContext)
    {
        protected async override Task<bool> HandleCoreAsync()
        {
            var tag = await _tagDataService.GetAll()
                .Where(x => x.TagId == Request.TagId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (tag is null)
                return NotFound($"Tag with id {Request.TagId} not found");
            
            tag.IsActive = false;
            tag.UpdatedBy = 101;
            tag.UpdatedOn = DateTime.UtcNow;

            await _tagDataService.UpdateAsync(tag);

            Response.TagId = tag.TagId;
            return Success();
        }
    }
}
