using CleanArchitecture.Core.AccountAggregate.Events;
using CleanArchitecture.SharedKernel;
using System.Runtime.CompilerServices;

namespace CleanArchitecture.Core.AccountAggregate;

public class Account : EntityBase
{

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool IsDone { get; set; }

    public void MarkComplete()
    {
        if (!IsDone)
        {
            IsDone = true;

            RegisterDomainEvent(new AccountCompletedEvent(this));
        }
    }

    public override string ToString()
    {
        string status = IsDone ? "Is Created!" : "Not Createxd.";
        return $"{Id}: Status: {status} - {Name} - {Email}";
    }
}