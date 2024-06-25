using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Module;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Utilities;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.Module
{
    /// <inheritdoc/>
    public class AclPageRepository : IAclPageRepository
    {
        private readonly IAclPageRouteRepository _routeRepository;
        private readonly IAclUserRepository _aclUserRepository;
        private readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclPageRepository(ApplicationDbContext dbContext, IAclPageRouteRepository routeRepository, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _routeRepository = routeRepository;
            _aclUserRepository = aclUserRepository;
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(ContextAccessor);
        }

        /// <inheritdoc/>
        public void DeletePageRouteByPageId(ulong pageId)
        {
            _routeRepository.DeleteAllByPageId(pageId);
        }
        /// <inheritdoc/>
        public List<AclPage>? All()
        {
            try
            {
                return _dbContext.AclPages.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclPage? Find(ulong id)
        {
            try
            {
                return _dbContext.AclPages.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPage? Add(AclPage aclPage)
        {
            try
            {
                _dbContext.AclPages.Add(aclPage);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclPage).ReloadAsync();
                return aclPage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPage? Update(AclPage aclPage)
        {
            try
            {
                _dbContext.AclPages.Update(aclPage);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclPage).ReloadAsync();
                return aclPage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPage? Delete(AclPage aclPage)
        {
            try
            {
                _dbContext.AclPages.Remove(aclPage);
                _dbContext.SaveChangesAsync();
                return aclPage;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPage? Delete(ulong id)
        {
            try
            {
                var delete = _dbContext.AclPages.Find(id);
                if (delete != null)
                    _dbContext.AclPages.Remove(delete);
                _dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public bool IsAclPageIdExist(ulong id)
        {
            return _dbContext.AclPages.Any(x => x.Id == id);
        }

        public bool IsModuleIdExist(ulong id)
        {
            return _dbContext.AclModules.Any(x => x.Id == id);
        }

        public bool IsSubModuleIdExist(ulong id)
        {
            return _dbContext.AclSubModules.Any(x => x.Id == id);
        }
        public bool IsExist(ulong id)
        {
            return _dbContext.AclPages.Any(i => i.Id == id);
        }
    }
}
