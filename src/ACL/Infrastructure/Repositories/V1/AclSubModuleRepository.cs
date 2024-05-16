
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclSubModuleRepository : IAclSubModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Sub Module";
        ApplicationDbContext _dbContext;

        public AclSubModuleRepository(ApplicationDbContext dbContext) 
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclSubModules = await _dbContext.AclSubModules
                .Join(_dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
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
            await _dbContext.AclSubModules.AddAsync(aclSubModule);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(aclSubModule).ReloadAsync();
            this.aclResponse.Data = aclSubModule;
            this.aclResponse.Message = this.messageResponse.createMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest request)
        {
            var aclSubModule = await _dbContext.AclSubModules.FindAsync(id);
            if (aclSubModule == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            aclSubModule = PrepareInputData(request, aclSubModule);
             _dbContext.AclSubModules.Update(aclSubModule);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(aclSubModule).ReloadAsync();
            this.aclResponse.Data = aclSubModule;
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }

        public async Task<AclResponse> FindById(ulong id)
        {

            var aclSubModule = await _dbContext.AclSubModules.Where(x=>x.Id == id)
               .Join(_dbContext.AclModules, sm => sm.ModuleId, m => m.Id, (sm, m) => new
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
            var subModule = await _dbContext.AclSubModules.FindAsync(id);

            if (subModule != null)
            {
                 _dbContext.AclSubModules.Remove(subModule);
                await _dbContext.SaveChangesAsync();
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
