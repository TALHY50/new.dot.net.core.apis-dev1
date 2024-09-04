using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class UserGroupRepository :EfRepository<Usergroup>, IUserGroupRepository
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        public static uint CompanyId = AppAuth.GetAuthInfo().CompanyId;
        /// <inheritdoc/>
        public readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private static IHttpContextAccessor _httpContextAccessor;

        /// <inheritdoc/>
        public UserGroupRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor):base(dbContext)
        {
            this._userRepository = userRepository;
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
        }
        /// <inheritdoc/>
        public uint SetCompanyId(uint companyId)
        {
            CompanyId = companyId;
            return CompanyId;
        }
        /// <inheritdoc/>
        public List<Usergroup>? All()
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
        public Usergroup? Find(uint id)
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
        public Usergroup? Add(Usergroup usergroup)
        {
            try
            {
                this._dbContext.AclUsergroups.Add(usergroup);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(usergroup).Reload();
                return usergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Usergroup? Update(Usergroup usergroup)
        {
            try
            {
                this._dbContext.AclUsergroups.Update(usergroup);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(usergroup).Reload();
                return usergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Usergroup? Delete(Usergroup usergroup)
        {
            try
            {
                this._dbContext.AclUsergroups.Remove(usergroup);
                this._dbContext.SaveChanges();
                return usergroup;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Usergroup? Deleted(uint id)
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

        public bool IsExist(uint id)
        {
            return this._dbContext.AclUsergroups.Any(m=> m.Id == id);
        }
    }
}
