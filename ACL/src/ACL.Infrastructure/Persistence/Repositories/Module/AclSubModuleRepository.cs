using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Module;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
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
        private enum SubModuleIds:ulong { _2001 = 2001,_2020 = 2020, _2021 = 2021, _2022 = 2022, _2050 =  2050, _2051 = 2051, _2052 = 2052, _2053 = 2053, _2054 = 2054, _2055 = 2055 };
        /// <inheritdoc/>
        public AclSubModuleRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _aclUserRepository = aclUserRepository;
            aclResponse = new AclResponse();
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(_httpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(_httpContextAccessor);
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
            aclResponse.Message = (aclResponse.Data!=null)?messageResponse.createMessage: messageResponse.createFail;
            aclResponse.StatusCode = (aclResponse.Data != null) ? AppStatusCode.SUCCESS : AppStatusCode.FAIL;
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclSubModuleRequest request)
        {
            var aclSubModule = Find(id);
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
            List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, id);
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
        /// <inheritdoc/>
        private bool SubModuleIdNotToDelete(ulong submoduleId)
        {
            bool exists = Enum.IsDefined(typeof(SubModuleIds), submoduleId);
            if (exists)
            {
                throw new InvalidOperationException("Id not to delete.");
            }
            return exists;
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
       
        /// <inheritdoc/>
        public string ExistByName(ulong? id, string name)
        {
            var valid = _dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower());
            if (id > 0)
            {
                valid = _dbContext.AclSubModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            if (valid)
            {
                throw new InvalidOperationException("Submodule Name does not unique.");
            }
            return name;
        }
        /// <inheritdoc/>
        public ulong ModuleIdExist(ulong moduleId)
        {
            var valid = _dbContext.AclModules.Any(x => x.Id == moduleId);

            if (!valid){
                throw new InvalidOperationException("Module Id does not exist.");
            }

            return moduleId;
        }


    }
}
