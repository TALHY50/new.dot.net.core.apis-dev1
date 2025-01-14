﻿using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IUserGroupRepository : IRepository<Usergroup>, IExtendedRepositoryBase<Usergroup>
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
