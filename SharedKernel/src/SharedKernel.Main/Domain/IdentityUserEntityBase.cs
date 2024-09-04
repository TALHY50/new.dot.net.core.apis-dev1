using Ardalis.SharedKernel;
using Microsoft.AspNetCore.Identity;

namespace SharedKernel.Main.Domain;

public abstract class IdentityUserEntityBase<TId> : HasIdentityDomainEventsBase<TId>
    where TId : struct, IEquatable<TId>
{
    //public TId Id { get; set; }
}