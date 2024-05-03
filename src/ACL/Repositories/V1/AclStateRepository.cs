
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Utilities;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;
using ACL.Services;

namespace ACL.Repositories.V1
{
    public class AclStateRepository : GenericRepository<AclState, ApplicationDbContext, ICustomUnitOfWork>, IAclStateRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "State";
        private ICustomUnitOfWork _customUnitOfWork;

        public AclStateRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            _customUnitOfWork = _unitOfWork;
            AppAuth.SetAuthInfo();
            aclResponse = new AclResponse();
            AppAuth.SetAuthInfo();
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclStates = await base.All();
            if (aclStates.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclStates;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclStateRequest request)
        {
            try
            {
                var aclState = PrepareInputData(request);
                await base.AddAsync(aclState);
                await _unitOfWork.CompleteAsync();
                await _customUnitOfWork.AclStateRepository.ReloadAsync(aclState);
                aclResponse.Data = aclState;
                aclResponse.Message = messageResponse.createMessage;
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
        public async Task<AclResponse> Edit(ulong id, AclStateRequest request)
        {
            var aclState = await base.GetById(id);
            if (aclState == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                return aclResponse;
            }
            try
            {
                aclState = PrepareInputData(request, aclState);
                await base.UpdateAsync(aclState);
                await _unitOfWork.CompleteAsync();
                await _customUnitOfWork.AclStateRepository.ReloadAsync(aclState);
                aclResponse.Data = aclState;
                aclResponse.Message = messageResponse.editMessage;
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

        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclState = await base.GetById(id);
                aclResponse.Data = aclState;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclState == null)
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
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
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var aclState = await base.GetById(id);

            if (aclState != null)
            {
                await base.DeleteAsync(aclState);
                await _unitOfWork.CompleteAsync();
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;

        }

        private AclState PrepareInputData(AclStateRequest request, AclState aclState = null)
        {
            if (aclState == null)
            {
                aclState = new AclState();
                aclState.CreatedAt = DateTime.Now;
                aclState.CreatedById = AppAuth.GetAuthInfo().UserId;
            }
            aclState.Name = request.Name;
            aclState.Status = request.Status;
            aclState.Description = request.Description;
            aclState.Sequence = request.Sequence;
            aclState.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclState.UpdatedAt = DateTime.Now;

            return aclState;
        }
    }
}
