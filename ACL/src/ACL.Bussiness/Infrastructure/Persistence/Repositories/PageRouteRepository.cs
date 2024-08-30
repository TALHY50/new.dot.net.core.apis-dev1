using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Entities;
using ACL.Bussiness.Infrastructure.Auth.Auth;
using ACL.Bussiness.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Bussiness.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class PageRouteRepository : IPageRouteRepository
    {
        /// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Page Routes";
        private readonly IUserRepository _userRepository;
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public PageRouteRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            this._userRepository = userRepository;
            this._dbContext = dbContext;
            this.ScopeResponse = new ScopeResponse();
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(ContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public PageRoute? Add(PageRoute pageRoute)
        {
            try
            {
                this._dbContext.AclPageRoutes.Add(pageRoute);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(pageRoute).ReloadAsync();
                return pageRoute;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public List<PageRoute>? All()
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
        public PageRoute? Delete(PageRoute pageRoute)
        {
            try
            {
                this._dbContext.AclPageRoutes.Remove(pageRoute);
                this._dbContext.SaveChangesAsync();
                return pageRoute;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public PageRoute? Delete(ulong id)
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
        public PageRoute[]? DeleteAllByPageId(ulong pageId)
        {
            try
            {
                List<PageRoute>? pageRoutes = this._dbContext.AclPageRoutes.Where(r => r.PageId == pageId).ToList();
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
        public PageRoute? Find(ulong id)
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
        public PageRoute PreparePageRouteInputData(AclPageRouteRequest request, PageRoute? aclPageRoute = null)
        {
            if (aclPageRoute == null)
            {
                return new PageRoute
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
        public PageRoute? Update(PageRoute pageRoute)
        {
            try
            {
                this._dbContext.AclPageRoutes.Update(pageRoute);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(pageRoute).ReloadAsync();
                return pageRoute;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
