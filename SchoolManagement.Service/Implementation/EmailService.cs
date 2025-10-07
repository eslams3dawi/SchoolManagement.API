//using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using SchoolManagement.Data.Helpers;
using SchoolManagement.Service.Interfaces;
using System.Net;
using System.Net.Mail;

namespace SchoolManagement.Service.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task<string> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.From, _emailSettings.DisplayName),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);
                using var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
                {
                    Credentials = new NetworkCredential(_emailSettings.From, _emailSettings.Password),
                    EnableSsl = _emailSettings.EnableSSL
                };
                await client.SendMailAsync(mailMessage);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                return "Failed To Send";
            }
        }
    }
}
