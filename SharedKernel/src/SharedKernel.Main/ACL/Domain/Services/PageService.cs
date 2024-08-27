using Microsoft.AspNetCore.Http;
using SharedKernel.Main.ACL.Application.Interfaces.Repositories;
using SharedKernel.Main.ACL.Contracts.Requests;
using SharedKernel.Main.ACL.Contracts.Responses;
using SharedKernel.Main.ACL.Domain.Entities;
using SharedKernel.Main.ACL.Infrastructure.Persistence.Context;
using SharedKernel.Main.ACL.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Infrastructure.Auth;

namespace SharedKernel.Main.ACL.Domain.Services
{
    public class PageService : PageRepository, IPageService
    {
        /// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        public Page Page;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Page";
        private readonly IPageRouteRepository _routeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _dbContext;
        public new static IHttpContextAccessor ContextAccessor { get; private set; }
        public PageService(ApplicationDbContext dbContext, IPageRouteRepository routeRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, routeRepository, userRepository, httpContextAccessor)
        {
            this._dbContext = dbContext;
            this.ScopeResponse = new ScopeResponse();
            this._routeRepository = routeRepository;
            this._userRepository = userRepository;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(ContextAccessor);
        }
        /// <inheritdoc/>
        public ScopeResponse GetAll()
        {
            List<Page>? aclPage = All();
            if (aclPage != null)
            {
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.ScopeResponse.Data = aclPage;
            this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            this.ScopeResponse.Timestamp = DateTime.Now;

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse AddAclPage(AclPageRequest request)
        {
            try
            {
                Page? aclPage = PrepareInputData(request);
                this.ScopeResponse.Data = Add(aclPage);
                this.ScopeResponse.Message = this.MessageResponse.createMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse EditAclPage(AclPageRequest request)
        {
            Page? aclPage = Find(request.Id);
            try
            {
                if (aclPage == null)
                {
                    throw new InvalidOperationException("Page id not found");
                }
                aclPage = PrepareInputData(request, aclPage);
                this.ScopeResponse.Data = Update(aclPage);
                this.ScopeResponse.Message = this.MessageResponse.editMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, request.Id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }

        /// <inheritdoc/>
        public ScopeResponse FindById(ulong id)
        {
            try
            {
                Page? aclPage = Find(id);
                this.ScopeResponse.Data = aclPage;
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
                if (aclPage == null)
                {
                    this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                }

                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse DeleteById(ulong id)
        {
            Page? page = Find(id);
            try
            {
                if (page == null)
                {
                    throw new InvalidOperationException("Page id not found");
                }
                this.ScopeResponse.Data = Delete(page);
                this._routeRepository.DeleteAllByPageId(id);
                this.ScopeResponse.Message = this.MessageResponse.deleteMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            catch (Exception e)
            {
                this.ScopeResponse.Message = e.Message;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.ScopeResponse;
        }


        private Page PrepareInputData(AclPageRequest request, Page? aclPage = null)
        {
            if (aclPage == null)
            {
                if (IsAclPageIdExist(request.Id))
                {
                    throw new InvalidOperationException("Page id already exist");
                }
                this.Page = new Page();
                this.Page.Id = request.Id;
                this.Page.CreatedAt = DateTime.Now;
            }
            else
            {
                this.Page = aclPage;
            }
            if (!IsModuleIdExist(request.ModuleId))
            {
                throw new InvalidOperationException("Module id not valid");
            }

            if (!IsSubModuleIdExist(request.SubModuleId))
            {
                throw new InvalidOperationException("Sub Module id not valid");
            }
            this.Page.ModuleId = request.ModuleId;
            this.Page.SubModuleId = request.SubModuleId;
            this.Page.Name = request.Name;
            this.Page.MethodName = request.MethodName;
            this.Page.MethodType = request.MethodType;
            this.Page.CreatedAt = DateTime.Now;
            this.Page.UpdatedAt = DateTime.Now;
            return this.Page;
        }

        /// <inheritdoc/>
        public ScopeResponse PageRouteCreate(AclPageRouteRequest request)
        {
            try
            {
                PageRoute pageRoute = PreparePageRouteInputData(request);
                this.ScopeResponse.Data = this._routeRepository.Add(pageRoute);
                this.ScopeResponse.Message = "Page Routes Create Successfully";
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse PageRouteEdit(ulong id, AclPageRouteRequest request)
        {
            try
            {
                PageRoute? aclPageRoute = this._routeRepository.Find(id);
                if (aclPageRoute == null)
                {
                    throw new InvalidOperationException("Page route id not found");
                }
                // clear version
                List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, request.PageId);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
                PageRoute? aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                this.ScopeResponse.Data = this._routeRepository.Update(aclPageRouteUpdateData);
                this.ScopeResponse.Message = "Page Routes Updated Successfully";
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse PageRouteDelete(ulong id)
        {
            PageRoute? aclPageRoute = this._routeRepository.Find(id);
            try
            {
                if (aclPageRoute == null)
                {
                    throw new InvalidOperationException("Page route id not found");
                }
                List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, aclPageRoute.PageId);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
                this.ScopeResponse.Data = this._routeRepository.Delete(aclPageRoute);
                this.ScopeResponse.Message = "Page Routes Deleted Successfully";
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public PageRoute PreparePageRouteInputData(AclPageRouteRequest request, PageRoute? aclPageRoute = null)
        {
            if (!IsAclPageIdExist(request.PageId))
            {
                throw new InvalidOperationException("Page id not valid");
            }
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
    }
}
