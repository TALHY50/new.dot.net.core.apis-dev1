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
    public class AclModuleService : AclModuleRepository, IAclModuleService
    {/// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private readonly string _modelName = "Module";
        public new static IHttpContextAccessor HttpContextAccessor;

        /// <inheritdoc/>
        public AclModuleService(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor) : base(dbContext, aclUserRepository, httpContextAccessor)
        {
            _dbContext = dbContext;
            AclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            _aclUserRepository = aclUserRepository;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclModules = All();
            if (aclModules.Any())
            {
                AclResponse.Message = MessageResponse.fetchMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                AclResponse.Message = MessageResponse.notFoundMessage;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            AclResponse.Data = aclModules;
            AclResponse.Timestamp = DateTime.Now;

            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse AddAclModule(AclModuleRequest request)
        {
            try
            {
                var check = Find(request.Id);
                if (check == null)
                {
                    var aclModule = PrepareInputData(request);
                    AclResponse.Data = Add(aclModule);
                    AclResponse.Message = MessageResponse.createMessage;
                    AclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    AclResponse.Message = MessageResponse.existMessage;
                    AclResponse.StatusCode = AppStatusCode.FAIL;
                }
                AclResponse.Timestamp = DateTime.Now;
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
        public AclResponse EditAclModule(AclModuleRequest request)
        {
            try
            {
                var aclModule = Find(request.Id);
                if (aclModule != null)
                {
                    aclModule = PrepareInputData(request, aclModule);
                    AclResponse.Data = Update(aclModule);
                    AclResponse.Message = MessageResponse.editMessage;
                    AclResponse.StatusCode = AppStatusCode.SUCCESS;

                    List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(request.Id);
                    if (userIds != null)
                    {
                        _aclUserRepository.UpdateUserPermissionVersion(userIds);
                    }
                }
                else
                {
                    AclResponse.Message = MessageResponse.notFoundMessage;
                    AclResponse.StatusCode = AppStatusCode.FAIL;
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
                var aclModule = Find(id);
                AclResponse.Data = aclModule;
                AclResponse.Message = MessageResponse.fetchMessage;
                if (aclModule == null)
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
        public AclResponse DeleteModule(ulong id)
        {

            var aclModule = Find(id);

            if (aclModule != null)
            {
                AclResponse.Data = Delete(aclModule);
                AclResponse.Message = MessageResponse.deleteMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                AclResponse.Message = MessageResponse.notFoundMessage;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;
        }

        public AclModule PrepareInputData(AclModuleRequest request, AclModule? module = null)
        {
            AclModule aclModule = new AclModule();
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
