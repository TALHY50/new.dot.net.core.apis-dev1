using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Contracts;
using MessageResponse = SharedKernel.Main.Contracts.MessageResponse;

namespace ACL.Business.Domain.Services
{
    public class PageService : PageRepository, IPageService
    {
        /// <inheritdoc/>
        public ApplicationResponse ApplicationResponse;
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
            this.ApplicationResponse = new ApplicationResponse();
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
        public ApplicationResponse GetAll()
        {
            List<Page>? aclPage = All();
            if (aclPage != null)
            {
                this.ApplicationResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.ApplicationResponse.Data = aclPage;
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            this.ApplicationResponse.Timestamp = DateTime.Now;

            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse AddAclPage(AclPageRequest request)
        {
            try
            {
                Page? aclPage = PrepareInputData(request);
                this.ApplicationResponse.Data = Add(aclPage);
                this.ApplicationResponse.Message = this.MessageResponse.createMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse EditAclPage(AclPageRequest request)
        {
            Page? aclPage = Find(request.Id);
            try
            {
                if (aclPage == null)
                {
                    throw new InvalidOperationException("Page id not found");
                }
                aclPage = PrepareInputData(request, aclPage);
                this.ApplicationResponse.Data = Update(aclPage);
                this.ApplicationResponse.Message = this.MessageResponse.editMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
                List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, request.Id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }

        /// <inheritdoc/>
        public ApplicationResponse FindById(uint id)
        {
            try
            {
                Page? aclPage = Find(id);
                this.ApplicationResponse.Data = aclPage;
                this.ApplicationResponse.Message = this.MessageResponse.fetchMessage;
                if (aclPage == null)
                {
                    this.ApplicationResponse.Message = this.MessageResponse.notFoundMessage;
                }

                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;

        }
        /// <inheritdoc/>
        public ApplicationResponse DeleteById(uint id)
        {
            Page? page = Find(id);
            try
            {
                if (page == null)
                {
                    throw new InvalidOperationException("Page id not found");
                }
                this.ApplicationResponse.Data = Delete(page);
                this._routeRepository.DeleteAllByPageId(id);
                this.ApplicationResponse.Message = this.MessageResponse.deleteMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
                List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            catch (Exception e)
            {
                this.ApplicationResponse.Message = e.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            return this.ApplicationResponse;
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
        public ApplicationResponse PageRouteCreate(AclPageRouteRequest request)
        {
            try
            {
                PageRoute pageRoute = PreparePageRouteInputData(request);
                this.ApplicationResponse.Data = this._routeRepository.Add(pageRoute);
                this.ApplicationResponse.Message = "Page Routes Create Successfully";
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse PageRouteEdit(uint id, AclPageRouteRequest request)
        {
            try
            {
                PageRoute? aclPageRoute = this._routeRepository.Find(id);
                if (aclPageRoute == null)
                {
                    throw new InvalidOperationException("Page route id not found");
                }
                // clear version
                List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, request.PageId);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
                PageRoute? aclPageRouteUpdateData = PreparePageRouteInputData(request, aclPageRoute);
                this.ApplicationResponse.Data = this._routeRepository.Update(aclPageRouteUpdateData);
                this.ApplicationResponse.Message = "Page Routes Updated Successfully";
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse PageRouteDelete(uint id)
        {
            PageRoute? aclPageRoute = this._routeRepository.Find(id);
            try
            {
                if (aclPageRoute == null)
                {
                    throw new InvalidOperationException("Page route id not found");
                }
                List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, aclPageRoute.PageId);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
                this.ApplicationResponse.Data = this._routeRepository.Delete(aclPageRoute);
                this.ApplicationResponse.Message = "Page Routes Deleted Successfully";
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            return this.ApplicationResponse;
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
