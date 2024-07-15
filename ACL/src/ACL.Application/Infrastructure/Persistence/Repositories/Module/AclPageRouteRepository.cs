using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Module;
using ACL.Application.Domain.Ports.Repositories.Auth;
using ACL.Application.Domain.Ports.Repositories.Module;
using ACL.Application.Infrastructure.Persistence.Configurations;
using ACL.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;

namespace ACL.Application.Infrastructure.Persistence.Repositories.Module
{
    /// <inheritdoc/>
    public class AclPageRouteRepository : IAclPageRouteRepository
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Page Route";
        private readonly IAclUserRepository _aclUserRepository;
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclPageRouteRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            _dbContext = dbContext;
            this.AclResponse = new AclResponse();
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(ContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public AclPageRoute? Add(AclPageRoute aclPageRoute)
        {
            try
            {
                _dbContext.AclPageRoutes.Add(aclPageRoute);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclPageRoute).ReloadAsync();
                return aclPageRoute;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public List<AclPageRoute>? All()
        {
            try
            {
                return _dbContext.AclPageRoutes.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclPageRoute? Delete(AclPageRoute aclPageRoute)
        {
            try
            {
                _dbContext.AclPageRoutes.Remove(aclPageRoute);
                _dbContext.SaveChangesAsync();
                return aclPageRoute;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclPageRoute? Delete(ulong id)
        {
            try
            {
                var delete = _dbContext.AclPageRoutes.Find(id);
                _dbContext.AclPageRoutes.Remove(delete);
                _dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPageRoute[]? DeleteAllByPageId(ulong pageId)
        {
            try
            {
                List<AclPageRoute>? pageRoutes = _dbContext.AclPageRoutes.Where(r => r.PageId == pageId).ToList();
                _dbContext.AclPageRoutes.RemoveRange(pageRoutes);
                _dbContext.SaveChanges();
                return pageRoutes.ToArray();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public AclPageRoute? Find(ulong id)
        {
            try
            {
                return _dbContext.AclPageRoutes.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute? aclPageRoute = null)
        {
            if (aclPageRoute == null)
            {
                return new AclPageRoute
                {
                    PageId = request.PageId,
                    RouteName = request.RouteName,
                    RouteUrl = request.RouteUrl,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
            }
            else
            {
                aclPageRoute.PageId = request.PageId;
                aclPageRoute.RouteName = request.RouteName;
                aclPageRoute.RouteUrl = request.RouteUrl;
                aclPageRoute.UpdatedAt = DateTime.Now;
                return aclPageRoute;
            }
        }
        /// <inheritdoc/>
        public AclPageRoute? Update(AclPageRoute aclPageRoute)
        {
            try
            {
                _dbContext.AclPageRoutes.Update(aclPageRoute);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclPageRoute).ReloadAsync();
                return aclPageRoute;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
