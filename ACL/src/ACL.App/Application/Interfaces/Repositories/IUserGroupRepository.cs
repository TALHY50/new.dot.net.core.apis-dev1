using ACL.App.Domain.Entities;

namespace ACL.App.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserGroupRepository
    {
        /// <inheritdoc/>
        ulong SetCompanyId(ulong companyId);
        /// <inheritdoc/>
        List<Usergroup>? All();
        /// <inheritdoc/>
        Usergroup? Find(ulong id);
        /// <inheritdoc/>
        Usergroup? Add(Usergroup userGroup);
        /// <inheritdoc/>
        Usergroup? Update(Usergroup userGroup);
        /// <inheritdoc/>
        Usergroup? Delete(Usergroup userGroup);
        /// <inheritdoc/>
        Usergroup? Deleted(ulong id);
        /// <inheritdoc/>
        bool IsExist(ulong id);
    }
}
