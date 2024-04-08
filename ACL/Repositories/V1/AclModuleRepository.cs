using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Repositories.V1
{
    public class AclModuleRepository : GenericRepository<AclModule>, IAclModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Module";
        public AclModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
        }
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclModule = await _unitOfWork.AclModuleRepository.GetById(id);
                aclResponse.Data = aclModule;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclModule == null)
                {
                    aclResponse.Message = messageResponse.noFoundMessage;
                }

                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> AddAclModule(AclModuleRequest request)
        {
            try
            {
                var check = await base.GetById(request.id);
                if (check == null)
                {
                    var aclModule = PrepareInputData(request);
                    _unitOfWork.AclModuleRepository.Add(aclModule);
                    await _unitOfWork.CompleteAsync();
                    await _unitOfWork.AclModuleRepository.ReloadAsync(aclModule);
                    aclResponse.Data = aclModule;
                    aclResponse.Message = messageResponse.createMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.Created;
                }
                else
                {
                    aclResponse.Message = messageResponse.existMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                }
                aclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> EditAclModule(ulong id, AclModuleRequest request)
        {
            try
            {
                var aclModule = await _unitOfWork.AclModuleRepository.GetById(id);
                if (aclModule != null)
                {
                    aclModule = PrepareInputData(request, aclModule);
                    await base.UpdateAsync(aclModule);
                    await _unitOfWork.CompleteAsync();
                    await _unitOfWork.AclModuleRepository.ReloadAsync(aclModule);
                    aclResponse.Data = aclModule;
                    aclResponse.Message = messageResponse.editMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    aclResponse.Message = messageResponse.noFoundMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
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
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            aclResponse.Data = aclModules;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public async Task<AclResponse> DeleteModule(ulong id)
        {

            var aclModule = await _unitOfWork.AclModuleRepository.GetById(id);

            if (aclModule != null)
            {
                await base.DeleteAsync(aclModule);
                await _unitOfWork.CompleteAsync();
                aclResponse.Data = aclModule;
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.Continue;
            }
            else
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
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
            aclModule.Id = request.id;
            aclModule.Name = request.name;
            aclModule.Icon = request.icon;
            aclModule.Sequence = request.sequence;
            aclModule.DisplayName = request.display_name;
            aclModule.UpdatedAt = DateTime.Now;
            if (_aclModule == null)
            {
                aclModule.CreatedAt = DateTime.Now;
            }
            return aclModule;

        }
    }
}
