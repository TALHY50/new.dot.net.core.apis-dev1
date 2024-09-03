using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserUserGroupRepository : IRepository<UserUsergroup>, IExtendedRepositoryBase<UserUsergroup>
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
