using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Auth;
using Notification.Application.Domain.Company;
using Notification.Application.Domain.Ports.Repositories.Company;
using Notification.Application.Infrastructure.Persistence.Configurations;
using Notification.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Claim = ACL.Application.Domain.Auth.Claim;

namespace ACL.Application.Infrastructure.Persistence.Repositories.Company
{
    /// <inheritdoc/>
    public class AclCompanyRepository : IAclCompanyRepository
    {
        
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Company Module";
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclCompanyRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            AclResponse = new AclResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            MessageResponse = new MessageResponse(_modelName, AppAuth.GetAuthInfo().Language);
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
                return _dbContext.AclCompanies.ToList();
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
                return _dbContext.AclCompanies.Find(id);
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
                _dbContext.AclCompanies.Add(aclCompany);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclCompany).ReloadAsync();
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
                _dbContext.AclCompanies.Update(aclCompany);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclCompany).ReloadAsync();
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
                _dbContext.AclCompanies.Remove(aclCompany);
                _dbContext.SaveChangesAsync();
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
                    _dbContext.AclCompanies.Remove(aclCompany);
                _dbContext.SaveChangesAsync();
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
                return _dbContext.AclCompanies.Any(i => i.Name == CompanyName);
            }
            else
            {
                return _dbContext.AclCompanies.Any(i => i.Name == CompanyName && i.Id != CompanyId);
            }
        }

        public bool UserIsExist(ulong userId)
        {
            return _dbContext.AclUsers.Any(i => i.Id == userId);
        }
        public bool UserGroupIsExist(ulong id)
        {
            return _dbContext.AclUsergroups.Any(m => m.Id == id);
        }
    }
}
