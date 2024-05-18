using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclModuleRepository : GenericRepository<AclModule>, IAclModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Module";

        public AclModuleRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }
        public async Task<AclResponse> GetAll()
        {
            var aclModules = await base.All();
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

        public async Task<AclResponse> AddAclModule(AclModuleRequest request)
        {
            try
            {
                var check = await base.GetById(request.Id);
                if (check == null)
                {
                    var aclModule = PrepareInputData(request);
                    base.Add(aclModule);
                    await base.CompleteAsync();
                    await base.ReloadAsync(aclModule);
                    this.aclResponse.Data = aclModule;
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
        public async Task<AclResponse> EditAclModule(ulong id, AclModuleRequest request)
        {
            try
            {
                var aclModule = await base.GetById(id);
                if (aclModule != null)
                {
                    aclModule = PrepareInputData(request, aclModule);
                    await base.UpdateAsync(aclModule);
                    await base.CompleteAsync();
                    await base.ReloadAsync(aclModule);
                    this.aclResponse.Data = aclModule;
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
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclModule = await base.GetById(id);
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

        public async Task<AclResponse> DeleteModule(ulong id)
        {

            var aclModule = await base.GetById(id);

            if (aclModule != null)
            {
                await base.DeleteAsync(aclModule);
                await base.CompleteAsync();
                this.aclResponse.Data = aclModule;
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
    }
}
