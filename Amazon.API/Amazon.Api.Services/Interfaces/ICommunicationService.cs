namespace Amazon.Api.Services.Interfaces
{
    public interface ICommunicationService
    {
        Task SendEmailAsync(string recipient, string subject, string body);
        string SendSMS(string phoneNumber, string body);
    }
}
