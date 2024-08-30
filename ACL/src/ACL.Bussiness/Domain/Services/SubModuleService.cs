using ACL.Bussiness.Application.Interfaces.Repositories;
using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Contracts.Responses;
using ACL.Bussiness.Domain.Entities;
using ACL.Bussiness.Infrastructure.Auth.Auth;
using ACL.Bussiness.Infrastructure.Persistence.Context;
using ACL.Bussiness.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Contracts.Common;

namespace ACL.Bussiness.Domain.Services
{
    public class SubModuleService : SubModuleRepository, ISubModuleService
    {
        /// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private readonly string modelName = "Sub Module";
        readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private static IHttpContextAccessor _httpContextAccessor;
        public SubModuleService(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, userRepository, httpContextAccessor)
        {
            this._userRepository = userRepository;
            this.ScopeResponse = new ScopeResponse();
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);

        }
        /// <inheritdoc/>
        public ScopeResponse GetAll()
        {
            var aclSubModules = this._dbContext.AclSubModules
                .Join(this._dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
                {
                    submodule = sm,
                    module = m

                }).ToList();
            if (aclSubModules.Count != 0)
            {
                this.ScopeResponse.Message = this.messageResponse.fetchMessage;
            }
            this.ScopeResponse.Data = aclSubModules;
            this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            this.ScopeResponse.Timestamp = DateTime.Now;

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse Add(AclSubModuleRequest request)
        {
            var exitAclSubModule = Find(request.Id);
            if (exitAclSubModule != null)
            {
                this.ScopeResponse.Message = this.messageResponse.ExistMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.CONFLICT;
                return this.ScopeResponse;
            }
            var aclSubModule = PrepareInputData(request);
            this.ScopeResponse.Data = Add(aclSubModule);
            this.ScopeResponse.Message = this.ScopeResponse.Data != null ? this.messageResponse.createMessage : this.messageResponse.createFail;
            this.ScopeResponse.StatusCode = this.ScopeResponse.Data != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse Edit(AclSubModuleRequest request)
        {
            var aclSubModule = Find(request.Id);
            if (aclSubModule == null)
            {
                this.ScopeResponse.Message = this.messageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.NOTFOUND;
                return this.ScopeResponse;
            }
            aclSubModule = PrepareInputData(request, aclSubModule);
            this.ScopeResponse.Data = Update(aclSubModule);
            this.ScopeResponse.Message = this.messageResponse.editMessage;
            this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, request.Id);
            if (userIds != null)
            {
                this._userRepository.UpdateUserPermissionVersion(userIds);
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse FindById(ulong id)
        {

            var aclSubModule = All()?.Where(x => x.Id == id)
               .Join(this._dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
               {
                   submodule = sm,
                   module = m

               }).FirstOrDefault();
            this.ScopeResponse.Data = aclSubModule;
            this.ScopeResponse.Message = this.messageResponse.fetchMessage;
            this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            if (aclSubModule == null)
            {
                this.ScopeResponse.StatusCode = AppStatusCode.NOTFOUND;
                this.ScopeResponse.Message = this.messageResponse.notFoundMessage;
            }

            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse DeleteById(ulong id)
        {
            this.ScopeResponse.StatusCode = AppStatusCode.NOTFOUND;
            var subModule = Find(id);

            if (subModule != null && !SubModuleIdNotToDelete(id))
            {
                this.ScopeResponse.Data = Delete(id);
                this.ScopeResponse.Message = this.messageResponse.deleteMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            return this.ScopeResponse;
        }

        private SubModule PrepareInputData(AclSubModuleRequest request, SubModule? aclSubModule = null)
        {
            if (aclSubModule == null)
            {
                aclSubModule = new SubModule
                {
                    Id = request.Id,
                    CreatedAt = DateTime.Now
                };
            }
            aclSubModule.ModuleId = ModuleIdExist(request.ModuleId);
            aclSubModule.Name = ExistByName(aclSubModule.Id, request.Name);
            aclSubModule.ControllerName = request.ControllerName;
            aclSubModule.DefaultMethod = request.DefaultMethod;
            aclSubModule.DisplayName = request.DisplayName;
            aclSubModule.Icon = request.Icon;
            aclSubModule.Sequence = request.Sequence;
            aclSubModule.UpdatedAt = DateTime.Now;
            return aclSubModule;
        }
    }
}
