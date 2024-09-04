namespace SharedKernel.Main.Domain;


public abstract class IdentityRoleEntityBase<TId> : HasIdentityRoleDomainEventBase<TId>
    where TId : struct, IEquatable<TId>
{
    //public TId Id { get; set; }
}