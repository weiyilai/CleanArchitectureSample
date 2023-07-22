using CleanArchitecture.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure;

public class SmtpEmailService : IEmailService
{
    private readonly ILogger<SmtpEmailService> _logger;

    public SmtpEmailService(
        ILogger<SmtpEmailService> logger
        )
    {
        _logger = logger;
    }

    public async Task SendAsync(
        string to, 
        string from, 
        string subject, 
        string body
        )
    {
        using SmtpClient emailClient = new("localhost");
        using MailMessage message = new();
        message.From = new MailAddress(from);
        message.Subject = subject;
        message.Body = body;
        message.To.Add(new MailAddress(to));
        await emailClient.SendMailAsync(message);
        _logger.LogWarning(
            "Sending email to {to} from {from} with subject {subject}.", 
            to, 
            from, 
            subject
            );
    }
}