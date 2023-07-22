using CleanArchitecture.SharedKernel;

namespace CleanArchitecture.Core.AccountAggregate.Events;

public class AccountAddedEvent : DomainEventBase
{
    public Account NewAccount { get; set; }

    public AccountAddedEvent(
        Account newAccount
        )
    {
        NewAccount = newAccount;
    }
}
