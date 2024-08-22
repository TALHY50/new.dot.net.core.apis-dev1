﻿using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.Auth;
using SharedKernel.Main.Application.Interfaces.Repositories.ACL.UserGroup;
using SharedKernel.Main.Domain.ACL.Domain.UserGroup;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;

namespace SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.UserGroup
{
    /// <inheritdoc/>
    public class AclUserGroupRepository : IAclUserGroupRepository
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        public static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;
        /// <inheritdoc/>
        public readonly AclApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private static IHttpContextAccessor _httpContextAccessor;

        /// <inheritdoc/>
        public AclUserGroupRepository(AclApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._aclUserRepository = aclUserRepository;
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public ulong SetCompanyId(ulong companyId)
        {
            CompanyId = companyId;
            return CompanyId;
        }
        /// <inheritdoc/>
        public List<AclUsergroup>? All()
        {
            try
            {
                return this._dbContext.AclUsergroups.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUsergroup? Find(ulong id)
        {
            try
            {
                return this._dbContext.AclUsergroups.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUsergroup? Add(AclUsergroup aclUsergroup)
        {
            try
            {
                this._dbContext.AclUsergroups.Add(aclUsergroup);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclUsergroup).Reload();
                return aclUsergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUsergroup? Update(AclUsergroup aclUsergroup)
        {
            try
            {
                this._dbContext.AclUsergroups.Update(aclUsergroup);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclUsergroup).Reload();
                return aclUsergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclUsergroup? Delete(AclUsergroup aclUsergroup)
        {
            try
            {
                this._dbContext.AclUsergroups.Remove(aclUsergroup);
                this._dbContext.SaveChanges();
                return aclUsergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclUsergroup? Deleted(ulong id)
        {
            try
            {
                var delete = Find(id);
                this._dbContext.AclUsergroups.Remove(delete);
                this._dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public bool IsExist(ulong id)
        {
            return this._dbContext.AclUserUsergroups.Any(m=> m.Id == id);
        }
    }
}