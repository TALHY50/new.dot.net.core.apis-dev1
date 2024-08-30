﻿using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface ICompanyModuleRepository
    {
        /// <inheritdoc/>
        List<Company>? All();
        /// <inheritdoc/>
        CompanyModule? Find(ulong id);
        /// <inheritdoc/>
        CompanyModule? Add(CompanyModule aclCompanyModule);
        /// <inheritdoc/>
        CompanyModule? Update(CompanyModule aclCompanyModule);
        /// <inheritdoc/>
        CompanyModule? Delete(CompanyModule aclCompanyModule);
        /// <inheritdoc/>
        CompanyModule? Delete(ulong id);

    }
}