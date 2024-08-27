using SharedKernel.Main.ACL.Domain.Entities;

namespace SharedKernel.Main.ACL.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserUserGroupRepository
    {
        /// <inheritdoc/>
        List<UserUsergroup>? All();
        /// <inheritdoc/>
        UserUsergroup? Find(ulong id);
        /// <inheritdoc/>
        UserUsergroup? Add(UserUsergroup acluseruserGroup);
        /// <inheritdoc/>
        UserUsergroup? Update(UserUsergroup userUserGroup);
        /// <inheritdoc/>
        UserUsergroup? Delete(UserUsergroup userUserGroup);
        /// <inheritdoc/>
        UserUsergroup? Delete(ulong id);
        /// <inheritdoc/>
        UserUsergroup[]? AddRange( UserUsergroup[]? userUserGroups);
        /// <inheritdoc/>
        UserUsergroup[]? RemoveRange( UserUsergroup[] userUserGroups);
        /// <inheritdoc/>
        UserUsergroup[]? Where(ulong userid);
        /// <inheritdoc/>
        UserUsergroup PrepareDataForInput(ulong userGroup, ulong userId);
    }
}
