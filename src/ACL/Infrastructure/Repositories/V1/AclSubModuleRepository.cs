using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclSubModuleRepository : GenericRepository<AclSubModule>, IAclSubModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Sub Module";

        public AclSubModuleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclSubModules = await base.Where(sm => true)
                .Join(base.Where(m => true), sm => sm.ModuleId, m => m.Id, (sm, m) => new
                {
                    submodule = sm,
                    module = m 

                }).ToListAsync();
            if (aclSubModules.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclSubModules;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        public async Task<AclResponse> Add(AclSubModuleRequest request)
        {

            var aclSubModule = PrepareInputData(request);
            await base.AddAsync(aclSubModule);
            await base.CompleteAsync();
            await base.ReloadAsync(aclSubModule);
            this.aclResponse.Data = aclSubModule;
            this.aclResponse.Message = this.messageResponse.createMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest request)
        {
            var aclSubModule = await base.GetById(id);
            if (aclSubModule == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            aclSubModule = PrepareInputData(request, aclSubModule);
            await base.UpdateAsync(aclSubModule);
            await base.CompleteAsync();
            await base.ReloadAsync(aclSubModule);
            this.aclResponse.Data = aclSubModule;
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }

        public async Task<AclResponse> FindById(ulong id)
        {

            var aclSubModule = await base.Where(sm => true).Where(x=>x.Id == id)
               .Join(base.Where(m => true), sm => sm.ModuleId, m => m.Id, (sm, m) => new
               {
                   submodule = sm,
                   module = m

               }).FirstOrDefaultAsync();
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
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var subModule = await base.GetById(id);

            if (subModule != null)
            {
                await base.DeleteAsync(subModule);
                await base.CompleteAsync();
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;

        }

        private AclSubModule PrepareInputData(AclSubModuleRequest request, AclSubModule aclSubModule = null)
        {
            if (aclSubModule == null)
            {
                aclSubModule = new AclSubModule();
                aclSubModule.Id = request.Id;
                aclSubModule.CreatedAt = DateTime.Now;
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
    }
}
