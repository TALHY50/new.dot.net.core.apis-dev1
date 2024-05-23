using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Module;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Persistence.Repositories.Auth;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.Module
{
    /// <inheritdoc/>
    public class AclModuleRepository : IAclModuleRepository
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        readonly ApplicationDbContext _dbContext;
        private readonly IAclUserRepository _aclUserRepository;
        private readonly string _modelName = "Module";
        public static IHttpContextAccessor HttpContextAccessor;

        /// <inheritdoc/>
        public AclModuleRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            this.AclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
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
        public AclResponse EditAclModule(ulong id, AclModuleRequest request)
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

                    List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(id);
                    if (userIds != null)
                    {
                        _aclUserRepository.UpdateUserPermissionVersion(userIds);
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
                List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(id);
                if (userIds != null)
                {
                    _aclUserRepository.UpdateUserPermissionVersion(userIds);
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
        /// <inheritdoc/>

        public bool ExistById(ulong? id, ulong value)
        {
            if (id > 0)
            {
                return _dbContext.AclModules.Any(x => x.Id == value && x.Id != id);
            }
            return _dbContext.AclModules.Any(x => x.Id == value);
        }
        /// <inheritdoc/>
        public bool ExistByName(ulong id, string name)
        {
            if (id > 0)
            {
                return _dbContext.AclModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            return _dbContext.AclModules.Any(x => x.Name.ToLower() == name.ToLower());
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
        /// <inheritdoc/>
        public List<AclModule>? All()
        {
            try
            {
                return _dbContext.AclModules.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclModule? Find(ulong id)
        {
            try
            {
                return _dbContext.AclModules.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclModule? Add(AclModule aclModule)
        {
            try
            {
                _dbContext.AclModules.Add(aclModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclModule).ReloadAsync();
                return aclModule;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclModule? Update(AclModule aclModule)
        {
            try
            {
                _dbContext.AclModules.Update(aclModule);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclModule).ReloadAsync();
                return aclModule;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclModule? Delete(AclModule aclModule)
        {
            try
            {
                _dbContext.AclModules.Remove(aclModule);
                _dbContext.SaveChanges();
                return aclModule;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclModule? Delete(ulong id)
        {
            try
            {
                var delete = Find(id);
                _dbContext.AclModules.Remove(delete);
                _dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
