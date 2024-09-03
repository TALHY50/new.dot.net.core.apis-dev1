using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserGroupRepository
    {
        /// <inheritdoc/>
        uint SetCompanyId(uint companyId);
        /// <inheritdoc/>
        List<Usergroup>? All();
        /// <inheritdoc/>
        Usergroup? Find(uint id);
        /// <inheritdoc/>
        Usergroup? Add(Usergroup userGroup);
        /// <inheritdoc/>
        Usergroup? Update(Usergroup userGroup);
        /// <inheritdoc/>
        Usergroup? Delete(Usergroup userGroup);
        /// <inheritdoc/>
        Usergroup? Deleted(uint id);
        /// <inheritdoc/>
        bool IsExist(uint id);
    }
}
