using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Module;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.Module
{
    /// <inheritdoc/>
    public class AclPageRepository : IAclPageRepository
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Page";
        private readonly IAclPageRouteRepository _routeRepository;
        private readonly IAclUserRepository _aclUserRepository;
        private readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclPageRepository(ApplicationDbContext dbContext, IAclPageRouteRepository routeRepository, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            this._routeRepository = routeRepository;
            _aclUserRepository = aclUserRepository;
            this.AclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(ContextAccessor);
        }

        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            List<AclPage>? aclPage = All();
            if (aclPage != null)
            {
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.AclResponse.Data = aclPage;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.AclResponse.Timestamp = DateTime.Now;

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse AddAclPage(AclPageRequest request)
        {
            try
            {
                AclPage? aclPage = PrepareInputData(request);
                this.AclResponse.Data = Add(aclPage);
                this.AclResponse.Message = this.MessageResponse.createMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse EditAclPage(ulong id, AclPageRequest request)
        {
            AclPage? aclPage = Find(id);
            if (aclPage == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                return this.AclResponse;
            }

            try
            {
                aclPage = PrepareInputData(request, aclPage);
                this.AclResponse.Data = Update(aclPage); ;
                this.AclResponse.Message = this.MessageResponse.editMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }

        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                AclPage? aclPage = Find(id);
                this.AclResponse.Data = aclPage;
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
                if (aclPage == null)
                {
                    this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                }

                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            AclPage? page = Find(id);
            if (page != null)
            {
                try
                {
                    this.AclResponse.Data = Delete(page);
                    _routeRepository.DeleteAllByPageId(id);
                    this.AclResponse.Message = this.MessageResponse.deleteMessage;
                    this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                    List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, id);
                    if (userIds != null)
                    {
                        _aclUserRepository.UpdateUserPermissionVersion(userIds);
                    }
                }
                catch (Exception)
                {
                    this.AclResponse.Message = this.MessageResponse.somethingIsWrong;
                    this.AclResponse.StatusCode = AppStatusCode.FAIL;
                }
            }
            else
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.AclResponse;

        }


        private AclPage PrepareInputData(AclPageRequest request, AclPage? aclPage = null)
        {
            if (aclPage == null)
            {
                aclPage = new AclPage();
                aclPage.CreatedAt = DateTime.Now;
            }
            aclPage.ModuleId = request.ModuleId;
            aclPage.SubModuleId = request.SubModuleId;
            aclPage.Name = request.Name;
            aclPage.MethodName = request.MethodName;
            aclPage.MethodType = request.MethodType;
            aclPage.CreatedAt = DateTime.Now;
            aclPage.UpdatedAt = DateTime.Now;
            return aclPage;
        }

        /// <inheritdoc/>
        public AclResponse PageRouteCreate(AclPageRouteRequest request)
        {
            this.MessageResponse.createMessage = "Page Route Create Successfully";
            try
            {
                AclPageRoute? aclPageRoute = PreparePageRouteInputData(request);
                this.AclResponse.Data = _routeRepository.Add(aclPageRoute);
                this.AclResponse.Message = this.MessageResponse.createMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse PageRouteEdit(ulong id, AclPageRouteRequest request)
        {
            this.MessageResponse.editMessage = "Page Route Update Successfully";
            try
            {
                AclPageRoute? aclPageRoute = _routeRepository.Find(id);
                if (aclPageRoute != null)
                {
                    // clear version
                    List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, request.PageId);
                    if (userIds != null)
                    {
                        _aclUserRepository.UpdateUserPermissionVersion(userIds);
                    }

                    AclPageRoute? aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                    this.AclResponse.Data = _routeRepository.Update(aclPageRouteUpdateData);
                    this.AclResponse.Message = this.MessageResponse.editMessage;
                    this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                    this.AclResponse.StatusCode = AppStatusCode.FAIL;
                    return this.AclResponse;
                }
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse PageRouteDelete(ulong id)
        {
            this.MessageResponse.deleteMessage = "Page Route Deleted Successfully";
            AclPageRoute? aclPageRoute = _routeRepository.Find(id);
            if (aclPageRoute != null)
            {
                this.AclResponse.Data = _routeRepository.Delete(aclPageRoute);
                this.AclResponse.Message = this.MessageResponse.deleteMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, aclPageRoute.PageId);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            return this.AclResponse;

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
        public void DeletePageRouteByPageId(ulong pageId)
        {
            _routeRepository.DeleteAllByPageId(pageId);
            //List<AclPageRoute>? pageRoutes = _dbContext.AclPageRoutes.Where(r => r.PageId == pageId).ToList();
            //_dbContext.AclPageRoutes.RemoveRange(pageRoutes);
            //_dbContext.SaveChanges();
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
                return null;
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
                return null;
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
                return null;
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
                return null;
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
                return null;
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
                return null;
            }

        }
        public bool IsExist(ulong id)
        {
            return _dbContext.AclPages.Any(i => i.Id == id);
        }
    }
}
