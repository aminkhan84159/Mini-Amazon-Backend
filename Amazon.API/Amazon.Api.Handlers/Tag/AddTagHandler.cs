using Amazon.Api.Core.ServiceFramework.Handlers;
using Amazon.Api.Data;
using Amazon.Api.Entities.Messages.Tag;
using Amazon.Api.Services.Interfaces;
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
            List<int> tagId = new List<int>();

            foreach (var tags in Request.Tags)
            {
                var tag = new Data.Entities.Tag()
                {
                    ProductId = Request.ProductId,
                    Tags = tags,
                    CreatedBy = 101,
                    CreatedOn = DateTime.UtcNow
                };

                tagId.Add(tag.TagId);

                await _tagDataService.AddAsync(tag);
            }

            Response.TagId = tagId;
            return Success();
        }
    }
}
