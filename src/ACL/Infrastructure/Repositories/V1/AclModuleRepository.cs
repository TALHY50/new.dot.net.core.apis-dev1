using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using ACL.UseCases.Interfaces.Repositories.V1;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclModuleRepository : IAclModuleRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private ApplicationDbContext _dbcontext;
        private string modelName = "Module";

        /// <inheritdoc/>
        public AclModuleRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclModules = All();
            if (aclModules.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Data = aclModules;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
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
                    this.aclResponse.Data = Add(aclModule);
                    this.aclResponse.Message = this.messageResponse.createMessage;
                    this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    this.aclResponse.Message = this.messageResponse.existMessage;
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                }
                this.aclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
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
                    this.aclResponse.Data = Update(aclModule);
                    this.aclResponse.Message = this.messageResponse.editMessage;
                    this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                }
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                var aclModule = Find(id);
                this.aclResponse.Data = aclModule;
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                if (aclModule == null)
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
                }

                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse DeleteModule(ulong id)
        {

            var aclModule = Find(id);

            if (aclModule != null)
            {
                this.aclResponse.Data = Delete(aclModule);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }
        /// <inheritdoc/>

        public bool ExistById(ulong? id, ulong value)
        {
            if (id > 0)
            {
                return _dbcontext.AclModules.Any(x => x.Id == value && x.Id != id);
            }
            return _dbcontext.AclModules.Any(x => x.Id == value);
        }
        /// <inheritdoc/>
        public bool ExistByName(ulong id, string name)
        {
            if (id > 0)
            {
                return _dbcontext.AclModules.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            return _dbcontext.AclModules.Any(x => x.Name.ToLower() == name.ToLower());
        }
        /// <inheritdoc/>
        public AclModule PrepareInputData(AclModuleRequest request, AclModule _aclModule = null)
        {
            AclModule aclModule = new AclModule();
            if (_aclModule != null)
            {
                aclModule.Id = request.Id;
                aclModule = _aclModule;
            }

            aclModule.Name = request.Name;
            aclModule.Icon = request.Icon;
            aclModule.Sequence = request.Sequence;
            aclModule.DisplayName = request.DisplayName;
            aclModule.UpdatedAt = DateTime.Now;
            if (_aclModule == null)
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
                return _dbcontext.AclModules.ToList();
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
                return _dbcontext.AclModules.Find(id);
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
                _dbcontext.AclModules.Add(aclModule);
                _dbcontext.SaveChanges();
                _dbcontext.Entry(aclModule).ReloadAsync();
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
                _dbcontext.AclModules.Update(aclModule);
                _dbcontext.SaveChanges();
                _dbcontext.Entry(aclModule).ReloadAsync();
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
                _dbcontext.AclModules.Remove(aclModule);
                _dbcontext.SaveChanges();
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
                _dbcontext.AclModules.Remove(delete);
                _dbcontext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
