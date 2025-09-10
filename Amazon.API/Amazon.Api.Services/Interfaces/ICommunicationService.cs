namespace Amazon.Api.Services.Interfaces
{
    public interface ICommunicationService
    {
        Task SendEmailAsync(string recipient, string subject, string body);
    }
}
