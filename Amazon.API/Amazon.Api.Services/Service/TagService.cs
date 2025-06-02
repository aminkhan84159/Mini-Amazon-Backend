using Amazon.Api.Core.Services;
using Amazon.Api.Data;
using Amazon.Api.Data.Entities;
using Amazon.Api.Data.Validators;
using Amazon.Api.Services.Interfaces;
using Serilog;

namespace Amazon.Api.Services.Service
{
    public class TagService : GenericService<Tag, TagValidator>, ITagService
    {
        public TagService(
            AmazonContext amazonContext,
            TagValidator entityValidator)
            : base(amazonContext, entityValidator)
        {
            
        }
    }
}
