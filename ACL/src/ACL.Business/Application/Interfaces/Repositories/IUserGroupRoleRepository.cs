using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserGroupRoleRepository : IRepository<UsergroupRole>, IExtendedRepositoryBase<UsergroupRole>
    {
        public uint RoleIdExist(uint roleId);
        public uint UserGroupIdExist(uint userGroupId);
        /// <inheritdoc/>
        List<UsergroupRole>? All();
        /// <inheritdoc/>
        UsergroupRole? Find(uint id);
        /// <inheritdoc/>
        UsergroupRole? Add(UsergroupRole userGroupRole);
        /// <inheritdoc/>
        UsergroupRole? Update(UsergroupRole userGroupRole);
        /// <inheritdoc/>
        UsergroupRole? Delete(UsergroupRole userGroupRole);
        /// <inheritdoc/>
        UsergroupRole? Delete(uint id);
        List<UsergroupRole>? FindByUserGroupId(uint userGroupId);

        UsergroupRole[]? AddAll(UsergroupRole[] aclUserGroupRoles);
        /// <inheritdoc/>
        UsergroupRole[]? DeleteAll(UsergroupRole[] aclUserG);
        public Task ReloadEntities(IEnumerable<UsergroupRole> entities);

        public bool IsExist(uint id);
        //{
        //    return this._dbContext.AclPages.Any(i => i.Id == id);
        //}

    }
}
