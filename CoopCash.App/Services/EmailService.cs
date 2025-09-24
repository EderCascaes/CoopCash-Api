using System.Net;
using System.Net.Mail;
using CoopCash.App.Interfaces.Services;
using CoopCash.Infra.Configurations;
using Microsoft.Extensions.Options;

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(IOptions<EmailSettings> options)
    {
        _settings = options.Value;
    }

    public async Task SendEmailAsync(string email, string subject, string body)
    {
        using var client = new SmtpClient(_settings.SmtpServer, _settings.Port)
        {
            UseDefaultCredentials = false, 
            Credentials = new NetworkCredential(_settings.User, _settings.Password),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_settings.FromEmail, "CoopCash - Sistema"),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(email);

        await client.SendMailAsync(mailMessage);
    }
}
