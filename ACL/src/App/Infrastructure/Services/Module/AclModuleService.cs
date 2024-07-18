using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Module;
using App.Domain.Ports.Repositories.Auth;
using App.Domain.Ports.Services.Module;
using App.Infrastructure.Persistence.Configurations;
using App.Infrastructure.Persistence.Repositories.Module;
using App.Infrastructure.Utilities;
using SharedKernel.Contracts.Response;

namespace App.Infrastructure.Services.Module
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
            this._dbContext = dbContext;
            this.AclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            this._aclUserRepository = aclUserRepository;
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
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Data = aclModules;
            this.AclResponse.Timestamp = DateTime.Now;

            return this.AclResponse;
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
                    this.AclResponse.Data = Add(aclModule);
                    this.AclResponse.Message = this.MessageResponse.createMessage;
                    this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    this.AclResponse.Message = this.MessageResponse.existMessage;
                    this.AclResponse.StatusCode = AppStatusCode.FAIL;
                }
                this.AclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
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
                    this.AclResponse.Data = Update(aclModule);
                    this.AclResponse.Message = this.MessageResponse.editMessage;
                    this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

                    List<ulong>? userIds = this._aclUserRepository.GetUserIdByChangePermission(request.Id);
                    if (userIds != null)
                    {
                        this._aclUserRepository.UpdateUserPermissionVersion(userIds);
                    }
                }
                else
                {
                    this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                    this.AclResponse.StatusCode = AppStatusCode.FAIL;
                }
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                var aclModule = Find(id);
                this.AclResponse.Data = aclModule;
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
                if (aclModule == null)
                {
                    this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                }

                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse DeleteModule(ulong id)
        {

            var aclModule = Find(id);

            if (aclModule != null)
            {
                this.AclResponse.Data = Delete(aclModule);
                this.AclResponse.Message = this.MessageResponse.deleteMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = this._aclUserRepository.GetUserIdByChangePermission(id);
                if (userIds != null)
                {
                    this._aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
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
