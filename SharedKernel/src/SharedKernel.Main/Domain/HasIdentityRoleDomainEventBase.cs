using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace SharedKernel.Main.Domain;


public abstract class HasIdentityRoleDomainEventBase<TId> : IdentityRole<TId> where TId : IEquatable<TId>
{
    private List<DomainEventBase> _domainEvents = new();
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();
}