using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Persistence.Database;
using ACL.Infrastructure.Utilities;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclPageRouteRepository : IAclPageRouteRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "Page Route";
        ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclPageRouteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
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
                return null;
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
                return null;
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
                return null;
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
                return null;
            }
        }
        /// <inheritdoc/>
        public AclPageRoute[]? DeleteAllByPageId(ulong pageid)
        {
            try
            {
                List<AclPageRoute>? pageRoutes = _dbContext.AclPageRoutes.Where(r => r.PageId == pageid).ToList();
                _dbContext.AclPageRoutes.RemoveRange(pageRoutes);
                _dbContext.SaveChanges();
                return pageRoutes.ToArray();
            }
            catch (Exception)
            {

                return null;
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
                return null;
            }

        }
        /// <inheritdoc/>
        public AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute aclPageRoute = null)
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
                return null;
            }
        }
    }
}
