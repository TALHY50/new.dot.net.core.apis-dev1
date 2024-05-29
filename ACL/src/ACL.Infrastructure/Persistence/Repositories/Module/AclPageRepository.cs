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
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "Page";
        private IAclPageRouteRepository routeRepository;
        private readonly IAclUserRepository _aclUserRepository;
        private ApplicationDbContext _dbContext;
        private static IHttpContextAccessor _httpContextAccessor;
        /// <inheritdoc/>
        public AclPageRepository(ApplicationDbContext dbContext, IAclPageRouteRepository _routeRepository, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            routeRepository = _routeRepository;
            _aclUserRepository = aclUserRepository;
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
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
        public AclResponse EditAclPage(AclPageRequest request)
        {
            AclPage? aclPage = Find(request.Id);
            try
            {
                if (aclPage == null)
                {
                    throw new InvalidOperationException("Page id not found");
                }
                aclPage = PrepareInputData(request, aclPage);
                this.aclResponse.Data = Update(aclPage);
                this.aclResponse.Message = this.messageResponse.editMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, request.Id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
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
            try
            {
                if (page == null)
                {
                    throw new InvalidOperationException("Page id not found");
                }
                this.aclResponse.Data = Delete(page);
                routeRepository.DeleteAllByPageId(id);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            catch (Exception e)
            {
                this.aclResponse.Message = e.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;
        }


        private AclPage PrepareInputData(AclPageRequest request, AclPage? AclPage = null)
        {
            if (AclPage == null)
            {
                if (isAclPageIdExist(request.Id))
                {
                    throw new InvalidOperationException("Page id already exist");
                }
                AclPage = new AclPage();
                AclPage.Id = request.Id;
                AclPage.CreatedAt = DateTime.Now;
            }
            if (!isModuleIdExist(request.ModuleId))
            {
                throw new InvalidOperationException("Module id not valid");
            }

            if (!isSubModuleIdExist(request.SubModuleId))
            {
                throw new InvalidOperationException("Sub Module id not valid");
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
            try
            {
                AclPageRoute aclPageRoute = PreparePageRouteInputData(request);
                this.aclResponse.Data = routeRepository.Add(aclPageRoute);
                this.aclResponse.Message = "Page Route Create Successfully";
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
            try
            {
                AclPageRoute? aclPageRoute = routeRepository.Find(id);
                if (aclPageRoute == null)
                {
                    throw new InvalidOperationException("Page route id not found");
                }
                // clear version
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, request.PageId);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
                AclPageRoute? aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                this.aclResponse.Data = routeRepository.Update(aclPageRouteUpdateData);
                this.aclResponse.Message = "Page Route Update Successfully";
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
        public AclResponse PageRouteDelete(ulong id)
        {
            AclPageRoute? aclPageRoute = routeRepository.Find(id);
            try
            {
                if (aclPageRoute == null)
                {
                    throw new InvalidOperationException("Page route id not found");
                }
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, aclPageRoute.PageId);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
                this.aclResponse.Data = routeRepository.Delete(aclPageRoute);
                this.aclResponse.Message = "Page Route Deleted Successfully";
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute? aclPageRoute = null)
        {
            if (!isAclPageIdExist(request.PageId))
            {
                throw new InvalidOperationException("Page id not valid");
            }
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

        public bool isAclPageIdExist(ulong id)
        {
            return _dbContext.AclPages.Any(x => x.Id == id);
        }

        public bool isModuleIdExist(ulong id)
        {
            return _dbContext.AclModules.Any(x => x.Id == id);
        }

        public bool isSubModuleIdExist(ulong id)
        {
            return _dbContext.AclSubModules.Any(x => x.Id == id);
        }


    }
}
