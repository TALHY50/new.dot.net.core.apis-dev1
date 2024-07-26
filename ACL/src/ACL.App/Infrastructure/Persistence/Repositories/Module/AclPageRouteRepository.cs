using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Response;
using ACL.App.Domain.Module;
using ACL.App.Domain.Ports.Repositories.Auth;
using ACL.App.Domain.Ports.Repositories.Module;
using ACL.App.Infrastructure.Persistence.Configurations;
using ACL.App.Infrastructure.Utilities;

namespace ACL.App.Infrastructure.Persistence.Repositories.Module
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
            this._aclUserRepository = aclUserRepository;
            this._dbContext = dbContext;
            this.AclResponse = new AclResponse();
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, this._dbContext);
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
                this._dbContext.AclPageRoutes.Add(aclPageRoute);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclPageRoute).ReloadAsync();
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
                return this._dbContext.AclPageRoutes.ToList();
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
                this._dbContext.AclPageRoutes.Remove(aclPageRoute);
                this._dbContext.SaveChangesAsync();
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
                var delete = this._dbContext.AclPageRoutes.Find(id);
                this._dbContext.AclPageRoutes.Remove(delete);
                this._dbContext.SaveChangesAsync();
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
                List<AclPageRoute>? pageRoutes = this._dbContext.AclPageRoutes.Where(r => r.PageId == pageId).ToList();
                this._dbContext.AclPageRoutes.RemoveRange(pageRoutes);
                this._dbContext.SaveChanges();
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
                return this._dbContext.AclPageRoutes.Find(id);
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
                this._dbContext.AclPageRoutes.Update(aclPageRoute);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(aclPageRoute).ReloadAsync();
                return aclPageRoute;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
