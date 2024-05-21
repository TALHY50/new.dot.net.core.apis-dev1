using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Module;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.Module
{
    /// <inheritdoc/>
    public class AclPageRepository : IAclPageRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "Page";
        private IAclPageRouteRepository routeRepository;
        private readonly IAclUserRepository _aclUserRepository;
        private ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclPageRepository(ApplicationDbContext dbContext, IAclPageRouteRepository _routeRepository, IAclUserRepository aclUserRepository)
        {
            _dbContext = dbContext;
            routeRepository = _routeRepository;
            _aclUserRepository = aclUserRepository;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            List<AclPage>? aclPage = All();
            if (aclPage != null)
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclPage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse AddAclPage(AclPageRequest request)
        {
            try
            {
                AclPage? aclPage = PrepareInputData(request);
                this.aclResponse.Data = Add(aclPage);
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse EditAclPage(ulong id, AclPageRequest request)
        {
            AclPage? aclPage = Find(id);
            if (aclPage == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            try
            {
                aclPage = PrepareInputData(request, aclPage);
                this.aclResponse.Data = Update(aclPage); ;
                this.aclResponse.Message = this.messageResponse.editMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong> user_ids = _aclUserRepository.GetUserIdByChangePermission(null, null, id);
                _aclUserRepository.UpdateUserPermissionVersion(user_ids);
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                AclPage? aclPage = Find(id);
                this.aclResponse.Data = aclPage;
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                if (aclPage == null)
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
                }

                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            AclPage? page = Find(id);
            if (page != null)
            {
                try
                {
                    this.aclResponse.Data = Delete(page);
                    routeRepository.DeleteAllByPageId(id);
                    this.aclResponse.Message = this.messageResponse.deleteMessage;
                    this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                    List<ulong> user_ids = _aclUserRepository.GetUserIdByChangePermission(null, null, id);
                    _aclUserRepository.UpdateUserPermissionVersion(user_ids);
                }
                catch (Exception)
                {
                    this.aclResponse.Message = this.messageResponse.somethingIsWrong;
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                }
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;

        }


        private AclPage PrepareInputData(AclPageRequest request, AclPage? AclPage = null)
        {
            if (AclPage == null)
            {
                AclPage = new AclPage();
                AclPage.CreatedAt = DateTime.Now;
            }
            AclPage.ModuleId = request.ModuleId;
            AclPage.SubModuleId = request.SubModuleId;
            AclPage.Name = request.Name;
            AclPage.MethodName = request.MethodName;
            AclPage.MethodType = request.MethodType;
            AclPage.CreatedAt = DateTime.Now;
            AclPage.UpdatedAt = DateTime.Now;
            return AclPage;
        }

        /// <inheritdoc/>
        public AclResponse PageRouteCreate(AclPageRouteRequest request)
        {
            this.messageResponse.createMessage = "Page Route Create Successfully";
            try
            {
                AclPageRoute? aclPageRoute = PreparePageRouteInputData(request);
                this.aclResponse.Data = routeRepository.Add(aclPageRoute);
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse PageRouteEdit(ulong id, AclPageRouteRequest request)
        {
            this.messageResponse.editMessage = "Page Route Update Successfully";
            try
            {
                AclPageRoute? aclPageRoute = routeRepository.Find(id);
                if (aclPageRoute != null)
                {
                    // clear version
                    List<ulong> user_ids = _aclUserRepository.GetUserIdByChangePermission(null, null, request.PageId);
                    _aclUserRepository.UpdateUserPermissionVersion(user_ids);

                    AclPageRoute? aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                    this.aclResponse.Data = routeRepository.Update(aclPageRouteUpdateData);
                    this.aclResponse.Message = this.messageResponse.editMessage;
                    this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                    return this.aclResponse;
                }
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse PageRouteDelete(ulong id)
        {
            this.messageResponse.deleteMessage = "Page Route Deleted Successfully";
            AclPageRoute? aclPageRoute = routeRepository.Find(id);
            if (aclPageRoute != null)
            {
                this.aclResponse.Data = routeRepository.Delete(aclPageRoute);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? user_ids = _aclUserRepository.GetUserIdByChangePermission(null, null, aclPageRoute.PageId);
                _aclUserRepository.UpdateUserPermissionVersion(user_ids);

            }
            return this.aclResponse;

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
            routeRepository.DeleteAllByPageId(pageId);
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
    }
}
