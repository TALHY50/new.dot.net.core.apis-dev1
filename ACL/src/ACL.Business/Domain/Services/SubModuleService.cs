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
    public class SubModuleService : SubModuleRepository, ISubModuleService
    {
        /// <inheritdoc/>
        public ApplicationResponse ApplicationResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private readonly string modelName = "Sub Module";
        readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private static IHttpContextAccessor _httpContextAccessor;
        public SubModuleService(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, userRepository, httpContextAccessor)
        {
            this._userRepository = userRepository;
            this.ApplicationResponse = new ApplicationResponse();
            this._dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);

        }
        /// <inheritdoc/>
        public ApplicationResponse GetAll()
        {
            var aclSubModules = this._dbContext.AclSubModules
                .Join(this._dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
                {
                    submodule = sm,
                    module = m

                }).ToList();
            if (aclSubModules.Count != 0)
            {
                this.ApplicationResponse.Message = this.messageResponse.fetchMessage;
            }
            this.ApplicationResponse.Data = aclSubModules;
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            this.ApplicationResponse.Timestamp = DateTime.Now;

            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse Add(AclSubModuleRequest request)
        {
            var exitAclSubModule = Find(request.Id);
            if (exitAclSubModule != null)
            {
                this.ApplicationResponse.Message = this.messageResponse.ExistMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_ALREADY_EXISTS;
                return this.ApplicationResponse;
            }
            var aclSubModule = PrepareInputData(request);
            this.ApplicationResponse.Data = Add(aclSubModule);
            this.ApplicationResponse.Message = this.ApplicationResponse.Data != null ? this.messageResponse.createMessage : this.messageResponse.createFail;
            this.ApplicationResponse.StatusCode = this.ApplicationResponse.Data != null ? ApplicationStatusCodes.API_SUCCESS : ApplicationStatusCodes.GENERAL_FAILURE;
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;

        }
        /// <inheritdoc/>
        public ApplicationResponse Edit(AclSubModuleRequest request)
        {
            var aclSubModule = Find(request.Id);
            if (aclSubModule == null)
            {
                this.ApplicationResponse.Message = this.messageResponse.notFoundMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
                return this.ApplicationResponse;
            }
            aclSubModule = PrepareInputData(request, aclSubModule);
            this.ApplicationResponse.Data = Update(aclSubModule);
            this.ApplicationResponse.Message = this.messageResponse.editMessage;
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(null, request.Id);
            if (userIds != null)
            {
                this._userRepository.UpdateUserPermissionVersion(userIds);
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;

        }
        /// <inheritdoc/>
        public ApplicationResponse FindById(uint id)
        {

            var aclSubModule = All()?.Where(x => x.Id == id)
               .Join(this._dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
               {
                   submodule = sm,
                   module = m

               }).FirstOrDefault();
            this.ApplicationResponse.Data = aclSubModule;
            this.ApplicationResponse.Message = this.messageResponse.fetchMessage;
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            if (aclSubModule == null)
            {
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
                this.ApplicationResponse.Message = this.messageResponse.notFoundMessage;
            }

            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse DeleteById(uint id)
        {
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
            var subModule = Find(id);

            if (subModule != null && !SubModuleIdNotToDelete(id))
            {
                this.ApplicationResponse.Data = Delete(id);
                this.ApplicationResponse.Message = this.messageResponse.deleteMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
                List<uint>? userIds = this._userRepository.GetUserIdByChangePermission(null, id);
                if (userIds != null)
                {
                    this._userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            return this.ApplicationResponse;
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
