using CleanArchitecture.SharedKernel;
using System.Security.Principal;

namespace CleanArchitecture.Core.AccountAggregate.Events;

public class AccountCompletedEvent : DomainEventBase
{
    public Account CompletedItem { get; set; }

    public AccountCompletedEvent(Account completedItem)
    {
        CompletedItem = completedItem;
    }
}