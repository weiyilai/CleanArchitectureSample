﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.SharedKernel;

/// <summary>
/// This can be modified to EntityBase<TId> to support multiple key types (e.g. Guid)
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// Guid
    /// </summary>
    public string Id { get; set; }

    private List<DomainEventBase> _domainEvents = new();

    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();
}