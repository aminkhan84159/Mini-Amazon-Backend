using Amazon.Api.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Amazon.Api.Services.Service
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IConfiguration _configuration;

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
    }
}
