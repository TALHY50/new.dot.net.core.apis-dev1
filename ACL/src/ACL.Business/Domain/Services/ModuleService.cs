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
    public class ModuleService : ModuleRepository, IModuleService
    {/// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly string _modelName = "Module";
        public new static IHttpContextAccessor HttpContextAccessor;

        /// <inheritdoc/>
        public ModuleService(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, userRepository, httpContextAccessor)
        {
            this._dbContext = dbContext;
            this.ScopeResponse = new ScopeResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            this._userRepository = userRepository;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
        /// <inheritdoc/>
        public ScopeResponse GetAll()
        {
            var aclModules = All();
            if (aclModules.Any())
            {
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            else
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ScopeResponse.Data = aclModules;
            this.ScopeResponse.Timestamp = DateTime.Now;

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse AddAclModule(AclModuleRequest request)
        {
            try
            {
                var check = Find(request.Id);
                if (check == null)
                {
                    var aclModule = PrepareInputData(request);
                    this.ScopeResponse.Data = Add(aclModule);
                    this.ScopeResponse.Message = this.MessageResponse.createMessage;
                    this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
                }
                else
                {
                    this.ScopeResponse.Message = this.MessageResponse.existMessage;
                    this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                }
                this.ScopeResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse EditAclModule(AclModuleRequest request)
        {
            try
            {
                var aclModule = Find(request.Id);
                if (aclModule != null)
                {
                    aclModule = PrepareInputData(request, aclModule);
                    this.ScopeResponse.Data = Update(aclModule);
                    this.ScopeResponse.Message = this.MessageResponse.editMessage;
                    this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

                    List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(request.Id);
                    if (userIds != null)
                    {
                        this._userRepository.UpdateUserPermissionVersion(userIds);
                    }
                }
                else
                {
                    this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                    this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                }
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse FindById(uint id)
        {
            try
            {
                var aclModule = Find(id);
                this.ScopeResponse.Data = aclModule;
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
                if (aclModule == null)
                {
                    this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                }

                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse DeleteModule(uint id)
        {

            var aclModule = Find(id);

            if (aclModule != null)
            {
                this.ScopeResponse.Data = Delete(aclModule);
                this.ScopeResponse.Message = this.MessageResponse.deleteMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
                List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }

        public Module PrepareInputData(AclModuleRequest request, Module? module = null)
        {
            Module aclModule = new Module();
            if (module != null)
            {
                aclModule.Id = request.Id;
                aclModule = module;
            }

            aclModule.Name = request.Name;
            bool idAlreadyExist;
            bool nameAlreadyExist;
            if (module == null)
            {
                idAlreadyExist = IsModuleIdAlreadyExist(aclModule.Id);
                nameAlreadyExist = IsModuleNameAlreadyExist(aclModule.Name);
            }
            else
            {
                idAlreadyExist = IsModuleIdAlreadyExist(aclModule.Id, request.Id);
                nameAlreadyExist = IsModuleNameAlreadyExist(aclModule.Name, request.Id);
            }

            if (idAlreadyExist)
            {
                throw new Exception("Module Id already exist.");
            }
            if (idAlreadyExist)
            {
                throw new Exception("Module Name already exist.");
            }
            aclModule.Icon = request.Icon;
            aclModule.Sequence = request.Sequence;
            aclModule.DisplayName = request.DisplayName;
            aclModule.UpdatedAt = DateTime.Now;
            if (module == null)
            {
                aclModule.CreatedAt = DateTime.Now;
            }
            return aclModule;

        }
    }
}
