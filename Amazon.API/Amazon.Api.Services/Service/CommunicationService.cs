using Amazon.Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
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

        public CommunicationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string recipient, string subject, string body)
        {
            var email = Environment.GetEnvironmentVariable("EmailAddress");
            var password = Environment.GetEnvironmentVariable("EmailPassword");
            var host = _configuration.GetValue<string>("Email_Configuration:Host");
            var port = _configuration.GetValue<int>("Email_Configuration:Port");

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Credentials = new NetworkCredential(email, password);

            using var mailMessage = new MailMessage
            {
                From = new MailAddress(email!),
                Subject = subject,
                Body = body,
                IsBodyHtml = true // Important for sending HTML content
            };
            mailMessage.To.Add(new MailAddress(recipient));

            await smtpClient.SendMailAsync(mailMessage);
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
