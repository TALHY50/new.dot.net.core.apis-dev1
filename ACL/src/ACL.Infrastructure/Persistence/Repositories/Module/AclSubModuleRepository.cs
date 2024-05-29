using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Module;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.Module
{
    /// <inheritdoc/>
    public class AclSubModuleRepository : IAclSubModuleRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private readonly string modelName = "Sub Module";
        readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private static IHttpContextAccessor _httpContextAccessor;
        /// <inheritdoc/>
        public AclSubModuleRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            this.aclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
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
                return this.aclResponse;
            }
            var aclSubModule = PrepareInputData(request);
            this.aclResponse.Data = Add(aclSubModule);
            this.aclResponse.Message = (aclResponse.Data!=null)?this.messageResponse.createMessage: messageResponse.createFail;
            this.aclResponse.StatusCode = (aclResponse.Data != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclSubModuleRequest request)
        {
            var aclSubModule = Find(id);
            if (aclSubModule == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }
            aclSubModule = PrepareInputData(request, aclSubModule);
            this.aclResponse.Data = Update(aclSubModule);
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, id);
            if (userIds != null)
            {
                _aclUserRepository.UpdateUserPermissionVersion(userIds);
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

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
            this.aclResponse.Data = aclSubModule;
            this.aclResponse.Message = this.messageResponse.fetchMessage;
            if (aclSubModule == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
            }
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var subModule = Find(id);

            if (subModule != null)
            {
                this.aclResponse.Data = Delete(id);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
                }
            }

            return this.aclResponse;

        }
        /// <inheritdoc/>
        public bool ExistById(ulong? id, ulong value)
        {
            if (id > 0)
            {
                return _dbContext.AclSubModules.Any(x => x.Id == value && x.Id != id);
            }
            return _dbContext.AclSubModules.Any(x => x.Id == value);
        }
        /// <inheritdoc/>
        public bool ExistByName(ulong id, string name)
        {
            if (id > 0)
            {
                return _dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            return _dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower());
        }
        private static AclSubModule PrepareInputData(AclSubModuleRequest request, AclSubModule? aclSubModule = null)
        {
            if (aclSubModule == null)
            {
                aclSubModule = new AclSubModule
                {
                    Id = request.Id,
                    CreatedAt = DateTime.Now
                };
            }
            aclSubModule.ModuleId = request.ModuleId;
            aclSubModule.Name = request.Name;
            aclSubModule.ControllerName = request.ControllerName;
            aclSubModule.DefaultMethod = request.DefaultMethod;
            aclSubModule.DisplayName = request.DisplayName;
            aclSubModule.Icon = request.Icon;
            aclSubModule.Sequence = request.Sequence;
            aclSubModule.UpdatedAt = DateTime.Now;
            return aclSubModule;
        }
        /// <inheritdoc/>
        public List<AclSubModule>? All()
        {
            try
            {
                return _dbContext.AclSubModules.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public AclSubModule? Find(ulong id)
        {
           
            return _dbContext.AclSubModules.Find(id);
          

        }
        /// <inheritdoc/>
        public AclSubModule? Add(AclSubModule aclSubModule)
        {
           
                _dbContext.AclSubModules.Add(aclSubModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclSubModule).Reload();
                return aclSubModule;

        }
        /// <inheritdoc/>
        public AclSubModule? Update(AclSubModule aclSubModule)
        {
           
                _dbContext.AclSubModules.Update(aclSubModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclSubModule).Reload();
                return aclSubModule;
          
        }
        /// <inheritdoc/>
        public AclSubModule? Delete(AclSubModule aclSubModule)
        {
          
                _dbContext.AclSubModules.Remove(aclSubModule);
                _dbContext.SaveChanges();
                return aclSubModule;
            
        }
        /// <inheritdoc/>
        public AclSubModule? Delete(ulong id)
        {
           
                var delete = Find(id);
                _dbContext.AclSubModules.Remove(delete);
                _dbContext.SaveChanges();
                return delete;
           

        }
    }
}
