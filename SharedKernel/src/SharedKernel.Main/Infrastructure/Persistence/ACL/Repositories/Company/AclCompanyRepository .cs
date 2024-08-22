using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Company;
using SharedKernel.Main.Contracts.ACL.Response;
using SharedKernel.Main.Domain.ACL.Domain.Auth;
using SharedKernel.Main.Domain.ACL.Domain.Company;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;

namespace SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Company
{
    /// <inheritdoc/>
    public class AclCompanyRepository : IAclCompanyRepository
    {
        
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Company Module";
        readonly AclApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclCompanyRepository(AclApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            this.AclResponse = new AclResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public AclUserUsergroup PrepareDataForUserUserGroups(ulong? userGroup, ulong? userId)
        {
            bool userIdValid = UserIsExist(userId??0);
            if (!userIdValid || userId ==0 || userId == null)
            {
                throw new Exception("User Id not Valid");
            }
            bool userGroupIdValid = UserGroupIsExist(userGroup??0);
            if (!userGroupIdValid || userGroup ==0 || userGroup == null)
            {
                throw new Exception("User Group Id not Valid");
            }
            AclUserUsergroup aclUserUserGroup = new AclUserUsergroup
            {
                UserId = userId ?? 0,
                UsergroupId = userGroup ?? 0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return aclUserUserGroup;
        }
        /// <inheritdoc/>
        public List<AclCompany>? All()
        {
            try
            {
                return this._dbContext.AclCompanies.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclCompany? Find(ulong id)
        {
            try
            {
                return this._dbContext.AclCompanies.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclCompany? Add(AclCompany aclCompany)
        {
            try
            {
                IsCompanyNameUnique(aclCompany.Name);
                this._dbContext.AclCompanies.Add(aclCompany);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclCompany).ReloadAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclCompany? Update(AclCompany aclCompany)
        {
            try
            {
                IsCompanyNameUnique(aclCompany.Name, aclCompany.Id);
                this._dbContext.AclCompanies.Update(aclCompany);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclCompany).ReloadAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclCompany? Delete(AclCompany aclCompany)
        {
            try
            {
                this._dbContext.AclCompanies.Remove(aclCompany);
                this._dbContext.SaveChangesAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclCompany? Delete(ulong id)
        {
            try
            {
                var aclCompany = Find(id);
                if (aclCompany != null)
                    this._dbContext.AclCompanies.Remove(aclCompany);
                this._dbContext.SaveChangesAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public bool IsCompanyNameUnique(string CompanyName, ulong? CompanyId = null)
        {
            if (CompanyId == null)
            {
                return this._dbContext.AclCompanies.Any(i => i.Name == CompanyName);
            }
            else
            {
                return this._dbContext.AclCompanies.Any(i => i.Name == CompanyName && i.Id != CompanyId);
            }
        }

        public bool UserIsExist(ulong userId)
        {
            return this._dbContext.AclUsers.Any(i => i.Id == userId);
        }
        public bool UserGroupIsExist(ulong id)
        {
            return this._dbContext.AclUsergroups.Any(m => m.Id == id);
        }
    }
}
