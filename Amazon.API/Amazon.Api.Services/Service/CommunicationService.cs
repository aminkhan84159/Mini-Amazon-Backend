using Amazon.Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Amazon.Api.Services.Service
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IConfiguration _configuration;
        public string AccountSID = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID")!;
        public string AuthToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN")!;
        public string EmailAddress = Environment.GetEnvironmentVariable("EmailAddress")!;
        public string EmailAPIKey = Environment.GetEnvironmentVariable("EmailAPIKey")!;

        public CommunicationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string recipient, string subject, string body)
        {
            var client = new SendGridClient(EmailAPIKey); //SendGrid Email Service to send mails
            var from = new EmailAddress(EmailAddress);
            var to = new EmailAddress(recipient);
            var plainTextContent = "Please view this email in an HTML-compatible client.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, body);

            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to send email. Status Code: {response.StatusCode}");
            }
        }

        public string SendSMS(string phoneNumber, string messageBody)
        {
            TwilioClient.Init(AccountSID, AuthToken);

            var message = MessageResource.Create(
            to: new PhoneNumber(phoneNumber), // Recipient's phone number
            from: new PhoneNumber("+14406717965"), // Your Twilio phone number
            body: messageBody
            );

            return message.ToString()!;
        }
    }
}
