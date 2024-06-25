using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Services.Module;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Persistence.Repositories.Module;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Infrastructure.Services.Module
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
            _aclUserRepository = aclUserRepository;
            aclResponse = new AclResponse();
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            messageResponse = new MessageResponse(modelName, AppAuth.GetAuthInfo().Language);

        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclSubModules = _dbContext.AclSubModules
                .Join(_dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
                {
                    submodule = sm,
                    module = m

                }).ToList();
            if (aclSubModules.Count != 0)
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclSubModules;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclSubModuleRequest request)
        {
            var exitAclSubModule = Find(request.Id);
            if (exitAclSubModule != null)
            {
                aclResponse.Message = messageResponse.ExistMessage;
                aclResponse.StatusCode = AppStatusCode.CONFLICT;
                return aclResponse;
            }
            var aclSubModule = PrepareInputData(request);
            aclResponse.Data = Add(aclSubModule);
            aclResponse.Message = aclResponse.Data != null ? messageResponse.createMessage : messageResponse.createFail;
            aclResponse.StatusCode = aclResponse.Data != null ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse Edit(AclSubModuleRequest request)
        {
            var aclSubModule = Find(request.Id);
            if (aclSubModule == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = AppStatusCode.NOTFOUND;
                return aclResponse;
            }
            aclSubModule = PrepareInputData(request, aclSubModule);
            aclResponse.Data = Update(aclSubModule);
            aclResponse.Message = messageResponse.editMessage;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;
            List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, request.Id);
            if (userIds != null)
            {
                _aclUserRepository.UpdateUserPermissionVersion(userIds);
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclSubModule = All()?.Where(x => x.Id == id)
               .Join(_dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
               {
                   submodule = sm,
                   module = m

               }).FirstOrDefault();
            aclResponse.Data = aclSubModule;
            aclResponse.Message = messageResponse.fetchMessage;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;
            if (aclSubModule == null)
            {
                aclResponse.StatusCode = AppStatusCode.NOTFOUND;
                aclResponse.Message = messageResponse.notFoundMessage;
            }

            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            aclResponse.StatusCode = AppStatusCode.NOTFOUND;
            var subModule = Find(id);

            if (subModule != null && !SubModuleIdNotToDelete(id))
            {
                aclResponse.Data = Delete(id);
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            return aclResponse;
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
