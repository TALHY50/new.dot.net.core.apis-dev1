using ACL.App.Application.Interfaces.Repositories.Auth;
using ACL.App.Application.Interfaces.Services.Module;
using ACL.App.Infrastructure.Persistence.Configurations;
using ACL.App.Infrastructure.Persistence.Repositories.Module;
using ACL.App.Infrastructure.Utilities;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.Module;

namespace ACL.App.Infrastructure.Services.Module
{
    public class AclSubModuleService : AclSubModuleRepository, IAclSubModuleService
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private readonly string modelName = "Sub Module";
        readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private static IHttpContextAccessor _httpContextAccessor;
        public AclSubModuleService(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, aclUserRepository, httpContextAccessor)
        {
            this._aclUserRepository = aclUserRepository;
            this.aclResponse = new AclResponse();
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);

        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclSubModules = this._dbContext.AclSubModules
                .Join(this._dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
                {
                    submodule = sm,
                    module = m

                }).ToList();
            if (aclSubModules.Count != 0)
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclSubModules;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclSubModuleRequest request)
        {
            var exitAclSubModule = Find(request.Id);
            if (exitAclSubModule != null)
            {
                this.aclResponse.Message = this.messageResponse.ExistMessage;
                this.aclResponse.StatusCode = AppStatusCode.CONFLICT;
                return this.aclResponse;
            }
            var aclSubModule = PrepareInputData(request);
            this.aclResponse.Data = Add(aclSubModule);
            this.aclResponse.Message = this.aclResponse.Data != null ? this.messageResponse.createMessage : this.messageResponse.createFail;
            this.aclResponse.StatusCode = this.aclResponse.Data != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse Edit(AclSubModuleRequest request)
        {
            var aclSubModule = Find(request.Id);
            if (aclSubModule == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.NOTFOUND;
                return this.aclResponse;
            }
            aclSubModule = PrepareInputData(request, aclSubModule);
            this.aclResponse.Data = Update(aclSubModule);
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            List<ulong>? userIds = this._aclUserRepository.GetUserIdByChangePermission(null, request.Id);
            if (userIds != null)
            {
                this._aclUserRepository.UpdateUserPermissionVersion(userIds);
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclSubModule = All()?.Where(x => x.Id == id)
               .Join(this._dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
               {
                   submodule = sm,
                   module = m

               }).FirstOrDefault();
            this.aclResponse.Data = aclSubModule;
            this.aclResponse.Message = this.messageResponse.fetchMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            if (aclSubModule == null)
            {
                this.aclResponse.StatusCode = AppStatusCode.NOTFOUND;
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
            }

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            this.aclResponse.StatusCode = AppStatusCode.NOTFOUND;
            var subModule = Find(id);

            if (subModule != null && !SubModuleIdNotToDelete(id))
            {
                this.aclResponse.Data = Delete(id);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._aclUserRepository.GetUserIdByChangePermission(null, id);
                if (userIds != null)
                {
                    this._aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            return this.aclResponse;
        }

        private AclSubModule PrepareInputData(AclSubModuleRequest request, AclSubModule? aclSubModule = null)
        {
            if (aclSubModule == null)
            {
                aclSubModule = new AclSubModule
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
