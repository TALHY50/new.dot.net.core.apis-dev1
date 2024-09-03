using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using MessageResponse = SharedKernel.Main.Contracts.MessageResponse;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public ApplicationResponse ApplicationResponse;
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Company Module";
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public CompanyRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            this.ApplicationResponse = new ApplicationResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.MessageResponse = new MessageResponse(this._modelName, language: AppAuth.GetAuthInfo()?.Language ?? throw new InvalidOperationException());
        }
        /// <inheritdoc/>
        public UserUsergroup PrepareDataForUserUserGroups(uint? userGroup, uint? userId)
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
            UserUsergroup userUserGroup = new UserUsergroup
            {
                UserId = userId ?? 0,
                UsergroupId = userGroup ?? 0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            return userUserGroup;
        }
        /// <inheritdoc/>
        public List<Company>? All()
        {
            try
            {
                return this._dbContext.Companies.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Company? Find(uint id)
        {
            try
            {
                return this._dbContext.Companies.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Company? Add(Company aclCompany)
        {
            try
            {
                IsCompanyNameUnique(aclCompany.Name);
                this._dbContext.Companies.Add(aclCompany);
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
        public Company? Update(Company aclCompany)
        {
            try
            {
                IsCompanyNameUnique(aclCompany.Name, aclCompany.Id);
                this._dbContext.Companies.Update(aclCompany);
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
        public Company? Delete(Company aclCompany)
        {
            try
            {
                this._dbContext.Companies.Remove(aclCompany);
                this._dbContext.SaveChangesAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Company? Delete(uint id)
        {
            try
            {
                var aclCompany = Find(id);
                if (aclCompany != null)
                    this._dbContext.Companies.Remove(aclCompany);
                this._dbContext.SaveChangesAsync();
                return aclCompany;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public bool IsCompanyNameUnique(string CompanyName, uint? CompanyId = null)
        {
            if (CompanyId == null)
            {
                return this._dbContext.Companies.Any(i => i.Name == CompanyName);
            }
            else
            {
                return this._dbContext.Companies.Any(i => i.Name == CompanyName && i.Id != CompanyId);
            }
        }

        public bool UserIsExist(uint userId)
        {
            return this._dbContext.AclUsers.Any(i => i.Id == userId);
        }
        public bool UserGroupIsExist(uint id)
        {
            return this._dbContext.AclUsergroups.Any(m => m.Id == id);
        }
    }
}
