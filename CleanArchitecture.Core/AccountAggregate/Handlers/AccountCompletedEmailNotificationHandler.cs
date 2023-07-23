using Ardalis.GuardClauses;
using CleanArchitecture.Core.AccountAggregate.Events;
using CleanArchitecture.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Core.AccountAggregate.Handlers;

public class AccountCompletedEmailNotificationHandler : INotificationHandler<AccountCompletedEvent>
{
    private readonly ILogger<AccountCompletedEmailNotificationHandler> _logger;
    private readonly IEmailService _emailService;

    public AccountCompletedEmailNotificationHandler(
        ILogger<AccountCompletedEmailNotificationHandler> logger, 
        IEmailService emailService
        )
    {
        _logger = logger;
        _emailService = emailService;
    }

    public Task Handle(AccountCompletedEvent notification, CancellationToken cancellationToken)
    {
        Guard.Against.Null(notification, nameof(notification));
        return _emailService.SendAsync(
            "joy777park@laiweiyi.com",
            notification.CompletedItem.Email,
            $"{notification.CompletedItem.Name} your account was created.",
            notification.CompletedItem.ToString()
            );
    }
}
