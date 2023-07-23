using CleanArchitecture.Core.Interfaces;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

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
        string from, 
        string to, 
        string subject, 
        string body
        )
    {
        string? apiKey = Environment.GetEnvironmentVariable("SendGrid_Api_Key");
        string plainTextContent = subject;
        string htmlContent = $"<strong>{body}</strong>";
        SendGridClient emailClient = new(apiKey);
        EmailAddress fromEmail = new(from, "Admin");
        EmailAddress toEmail = new(to);
        SendGridMessage msg = 
            MailHelper.CreateSingleEmail(
                fromEmail,
                toEmail, 
                subject, 
                plainTextContent, 
                htmlContent
                );
        var response = await emailClient.SendEmailAsync(msg);
        if (response != null && 
            response.IsSuccessStatusCode
            )
        {
            _logger.LogWarning(
                "Sending email to {to} from {from} with subject {subject}.",
                to,
                from,
                subject
                );
        }
    }
}