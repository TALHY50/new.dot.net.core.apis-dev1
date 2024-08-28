using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Entities;
using ACL.App.Infrastructure.Auth.Auth;
using ACL.App.Infrastructure.Persistence.Context;
using ACL.App.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace ACL.App.Domain.Services
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
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
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
                    this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    this.ScopeResponse.Message = this.MessageResponse.existMessage;
                    this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
                }
                this.ScopeResponse.Timestamp = DateTime.Now;
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
                    this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;

                    List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(request.Id);
                    if (userIds != null)
                    {
                        this._userRepository.UpdateUserPermissionVersion(userIds);
                    }
                }
                else
                {
                    this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                    this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
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
                var aclModule = Find(id);
                this.ScopeResponse.Data = aclModule;
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
                if (aclModule == null)
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
        public ScopeResponse DeleteModule(ulong id)
        {

            var aclModule = Find(id);

            if (aclModule != null)
            {
                this.ScopeResponse.Data = Delete(aclModule);
                this.ScopeResponse.Message = this.MessageResponse.deleteMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
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
