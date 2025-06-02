using Amazon.Api.Core.ServiceFramework.Enums;
using Amazon.Api.Core.ServiceFramework.Interfaces;

namespace Amazon.Api.Core.ServiceFramework.Messages
{
    public class ResponseBase : IResponseBase
    {
        public ResponseBase()
        {
            ValidationErrors = [];
        }

        public string? Exception { get; set; }
        public double ExecutionTimeSeconds { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ResponseStatusTypeEnum ResponseStatusType { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
