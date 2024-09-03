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
        UserUsergroup? Find(uint id);
        /// <inheritdoc/>
        UserUsergroup? Add(UserUsergroup acluseruserGroup);
        /// <inheritdoc/>
        UserUsergroup? Update(UserUsergroup userUserGroup);
        /// <inheritdoc/>
        UserUsergroup? Delete(UserUsergroup userUserGroup);
        /// <inheritdoc/>
        UserUsergroup? Delete(uint id);
        /// <inheritdoc/>
        UserUsergroup[]? AddRange( UserUsergroup[]? userUserGroups);
        /// <inheritdoc/>
        UserUsergroup[]? RemoveRange( UserUsergroup[] userUserGroups);
        /// <inheritdoc/>
        UserUsergroup[]? Where(uint userid);
        /// <inheritdoc/>
        UserUsergroup PrepareDataForInput(uint userGroup, uint userId);
    }
}
