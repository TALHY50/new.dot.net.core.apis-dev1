using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.Extensions.Localization;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;
using ACL.Services;
using ACL.Utilities;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Repositories.V1
{
    public class AclModuleRepository : GenericRepository<AclModule, ApplicationDbContext, ICustomUnitOfWork>, IAclModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Module";
        private ICustomUnitOfWork _customUnitOfWork;

        public AclModuleRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            _customUnitOfWork = _unitOfWork;
            aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclModule = await _customUnitOfWork.AclModuleRepository.GetById(id);
                aclResponse.Data = aclModule;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclModule == null)
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
                }

                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> AddAclModule(AclModuleRequest request)
        {
            try
            {
                var check = await base.GetById(request.Id);
                if (check == null)
                {
                    var aclModule = PrepareInputData(request);
                    _customUnitOfWork.AclModuleRepository.Add(aclModule);
                    await _unitOfWork.CompleteAsync();
                    await _customUnitOfWork.AclModuleRepository.ReloadAsync(aclModule);
                    aclResponse.Data = aclModule;
                    aclResponse.Message = messageResponse.createMessage;
                    aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    aclResponse.Message = messageResponse.existMessage;
                    aclResponse.StatusCode = AppStatusCode.FAIL;
                }
                aclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> EditAclModule(ulong id, AclModuleRequest request)
        {
            try
            {
                var aclModule = await _customUnitOfWork.AclModuleRepository.GetById(id);
                if (aclModule != null)
                {
                    aclModule = PrepareInputData(request, aclModule);
                    await base.UpdateAsync(aclModule);
                    await _unitOfWork.CompleteAsync();
                    await _customUnitOfWork.AclModuleRepository.ReloadAsync(aclModule);
                    aclResponse.Data = aclModule;
                    aclResponse.Message = messageResponse.editMessage;
                    aclResponse.StatusCode = AppStatusCode.SUCCESS;
                }
                else
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
                    aclResponse.StatusCode = AppStatusCode.FAIL;
                }
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclModules = await base.All();
            if (aclModules.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Data = aclModules;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public async Task<AclResponse> DeleteModule(ulong id)
        {

            var aclModule = await _customUnitOfWork.AclModuleRepository.GetById(id);

            if (aclModule != null)
            {
                await base.DeleteAsync(aclModule);
                await _unitOfWork.CompleteAsync();
                aclResponse.Data = aclModule;
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public AclModule PrepareInputData(AclModuleRequest request, AclModule _aclModule = null)
        {
            AclModule aclModule = new AclModule();
            if (_aclModule != null)
            {
                aclModule = _aclModule;
            }
            aclModule.Id = request.Id;
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
