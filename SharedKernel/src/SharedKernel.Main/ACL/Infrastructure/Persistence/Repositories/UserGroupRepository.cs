using Microsoft.AspNetCore.Http;
using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Domain.Entities;
using SharedKernel.Main.ACL.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Auth;

namespace SharedKernel.Main.ACL.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class UserGroupRepository : IUserGroupRepository
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        public static ulong CompanyId = AppAuth.GetAuthInfo().CompanyId;
        /// <inheritdoc/>
        public readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private static IHttpContextAccessor _httpContextAccessor;

        /// <inheritdoc/>
        public UserGroupRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._userRepository = userRepository;
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
        public Usergroup? Find(ulong id)
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
        public Usergroup? Deleted(ulong id)
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
