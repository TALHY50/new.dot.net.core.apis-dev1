using Notification.Application.Contracts.Requests;
using Notification.Application.Contracts.Response;
using Notification.Application.Domain.Module;
using Notification.Application.Domain.Ports.Repositories.Auth;
using Notification.Application.Domain.Ports.Repositories.Module;
using Notification.Application.Domain.Ports.Services.Module;
using Notification.Application.Infrastructure.Persistence.Configurations;
using Notification.Application.Infrastructure.Persistence.Repositories.Module;
using Notification.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Application.Infrastructure.Services.Module
{
    public class AclPageService : AclPageRepository, IAclPageService
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        public AclPage AclPage;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Page";
        private readonly IAclPageRouteRepository _routeRepository;
        private readonly IAclUserRepository _aclUserRepository;
        private readonly ApplicationDbContext _dbContext;
        public new static IHttpContextAccessor ContextAccessor { get; private set; }
        public AclPageService(ApplicationDbContext dbContext, IAclPageRouteRepository routeRepository, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, routeRepository, aclUserRepository, httpContextAccessor)
        {
            _dbContext = dbContext;
            AclResponse = new AclResponse();
            _routeRepository = routeRepository;
            _aclUserRepository = aclUserRepository;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            MessageResponse = new MessageResponse(_modelName, AppAuth.GetAuthInfo().Language);
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
                AclResponse.Message = MessageResponse.fetchMessage;
            }
            AclResponse.Data = aclPage;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;
            AclResponse.Timestamp = DateTime.Now;

            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse AddAclPage(AclPageRequest request)
        {
            try
            {
                AclPage? aclPage = PrepareInputData(request);
                AclResponse.Data = Add(aclPage);
                AclResponse.Message = MessageResponse.createMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;
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
                AclResponse.Data = Update(aclPage);
                AclResponse.Message = MessageResponse.editMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, request.Id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;
        }

        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                AclPage? aclPage = Find(id);
                AclResponse.Data = aclPage;
                AclResponse.Message = MessageResponse.fetchMessage;
                if (aclPage == null)
                {
                    AclResponse.Message = MessageResponse.notFoundMessage;
                }

                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;

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
                AclResponse.Data = Delete(page);
                _routeRepository.DeleteAllByPageId(id);
                AclResponse.Message = MessageResponse.deleteMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            catch (Exception e)
            {
                AclResponse.Message = e.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return AclResponse;
        }


        private AclPage PrepareInputData(AclPageRequest request, AclPage? aclPage = null)
        {
            if (aclPage == null)
            {
                if (IsAclPageIdExist(request.Id))
                {
                    throw new InvalidOperationException("Page id already exist");
                }
                AclPage = new AclPage();
                AclPage.Id = request.Id;
                AclPage.CreatedAt = DateTime.Now;
            }
            else
            {
                AclPage = aclPage;
            }
            if (!IsModuleIdExist(request.ModuleId))
            {
                throw new InvalidOperationException("Module id not valid");
            }

            if (!IsSubModuleIdExist(request.SubModuleId))
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
                AclResponse.Data = _routeRepository.Add(aclPageRoute);
                AclResponse.Message = "Page Route Create Successfully";
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse PageRouteEdit(ulong id, AclPageRouteRequest request)
        {
            try
            {
                AclPageRoute? aclPageRoute = _routeRepository.Find(id);
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
                AclResponse.Data = _routeRepository.Update(aclPageRouteUpdateData);
                AclResponse.Message = "Page Route Updated Successfully";
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse PageRouteDelete(ulong id)
        {
            AclPageRoute? aclPageRoute = _routeRepository.Find(id);
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
                AclResponse.Data = _routeRepository.Delete(aclPageRoute);
                AclResponse.Message = "Page Route Deleted Successfully";
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return AclResponse;
        }
        /// <inheritdoc/>
        public AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute? aclPageRoute = null)
        {
            if (!IsAclPageIdExist(request.PageId))
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
    }
}
