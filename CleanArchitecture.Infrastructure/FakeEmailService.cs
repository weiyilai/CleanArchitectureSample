using CleanArchitecture.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure;

public class FakeEmailService : IEmailService
{
    private readonly ILogger<FakeEmailService> _logger;

    public FakeEmailService(
        ILogger<FakeEmailService> logger
        )
    {
        _logger = logger;
    }

    public Task SendAsync(
        string from,
        string to,
        string subject, 
        string body
        )
    {
        _logger.LogInformation(
            "Not actually sending an email to {to} from {from} with subject {subject}.", 
            to, 
            from, 
            subject
            );
        return Task.CompletedTask;
    }
}