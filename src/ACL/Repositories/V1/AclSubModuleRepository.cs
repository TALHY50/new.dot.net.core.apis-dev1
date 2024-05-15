using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Core.Models;
using ACL.Requests;
using ACL.Response.V1;
using SharedLibrary.Services;
using ACL.Database;
using ACL.Utilities;
using SharedLibrary.Response.CustomStatusCode;
using Microsoft.EntityFrameworkCore;

namespace ACL.Repositories.V1
{
    public class AclSubModuleRepository : GenericRepository<AclSubModule, ApplicationDbContext, ICustomUnitOfWork>, IAclSubModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Sub Module";
        private ICustomUnitOfWork _customUnitOfWork;

        public AclSubModuleRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            _customUnitOfWork = _unitOfWork;
            AppAuth.SetAuthInfo();
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclSubModules = await _customUnitOfWork.AclSubModuleRepository.Where(sm => true)
                .Join(_customUnitOfWork.AclModuleRepository.Where(m => true), sm => sm.ModuleId, m => m.Id, (sm, m) => new
                {
                    submodule = sm,
                    module = m 

                }).ToListAsync();
            if (aclSubModules.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclSubModules;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclSubModuleRequest request)
        {

            var aclSubModule = PrepareInputData(request);
            await base.AddAsync(aclSubModule);
            await _customUnitOfWork.CompleteAsync();
            await _customUnitOfWork.AclSubModuleRepository.ReloadAsync(aclSubModule);
            aclResponse.Data = aclSubModule;
            aclResponse.Message = messageResponse.createMessage;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest request)
        {
            var aclSubModule = await base.GetById(id);
            if (aclSubModule == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                return aclResponse;
            }

            aclSubModule = PrepareInputData(request, aclSubModule);
            await base.UpdateAsync(aclSubModule);
            await _customUnitOfWork.CompleteAsync();
            await _customUnitOfWork.AclSubModuleRepository.ReloadAsync(aclSubModule);
            aclResponse.Data = aclSubModule;
            aclResponse.Message = messageResponse.editMessage;
            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }

        public async Task<AclResponse> FindById(ulong id)
        {

            var aclSubModule = await _customUnitOfWork.AclSubModuleRepository.Where(sm => true).Where(x=>x.Id == id)
               .Join(_customUnitOfWork.AclModuleRepository.Where(m => true), sm => sm.ModuleId, m => m.Id, (sm, m) => new
               {
                   submodule = sm,
                   module = m

               }).FirstOrDefaultAsync();
            aclResponse.Data = aclSubModule;
            aclResponse.Message = messageResponse.fetchMessage;
            if (aclSubModule == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
            }

            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var subModule = await base.GetById(id);

            if (subModule != null)
            {
                await base.DeleteAsync(subModule);
                await _customUnitOfWork.CompleteAsync();
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return aclResponse;

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
