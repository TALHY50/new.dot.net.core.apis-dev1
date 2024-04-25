
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Utilities;

namespace ACL.Repositories.V1
{
    public class AclCountryRepository : GenericRepository<AclCountry>, IAclCountryRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Country";
        public AclCountryRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork);
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
        }

        public async Task<AclResponse> GetAll()
        {
            var aclRoles = await base.All();
            if (aclRoles.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclRoles;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclCountryRequest request)
        {
            try
            {
                var aclCountry = PrepareInputData(request);
                await base.AddAsync(aclCountry);
                await _unitOfWork.CompleteAsync();
                await _unitOfWork.AclCountryRepository.ReloadAsync(aclCountry);
                aclResponse.Data = aclCountry;
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclCountryRequest request)
        {
            var aclCountry = await base.GetById(id);
            if (aclCountry == null)
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                return aclResponse;
            }
            try
            {
                aclCountry = PrepareInputData(request, aclCountry);
                await base.UpdateAsync(aclCountry);
                await _unitOfWork.CompleteAsync();
                await _unitOfWork.AclCountryRepository.ReloadAsync(aclCountry);
                aclResponse.Data = aclCountry;
                aclResponse.Message = messageResponse.editMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return aclResponse;

        }
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclRole = await base.GetById(id);
                aclResponse.Data = aclRole;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclRole == null)
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
            return aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var aclRole = await base.GetById(id);

            if (aclRole != null)
            {
                await base.DeleteAsync(aclRole);
                await _unitOfWork.CompleteAsync();
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;

        }
        private AclCountry PrepareInputData(AclCountryRequest request, AclCountry aclCountry = null)
        {
            if (aclCountry == null)
            {
                aclCountry = new AclCountry();
                aclCountry.CreatedById = AppAuth.GetAuthInfo().UserId;
                aclCountry.CreatedAt = DateTime.Now;
            }
            aclCountry.Name = request.name;
            aclCountry.Description = request.description;
            aclCountry.Code = request.code;
            aclCountry.Status = request.status;
            aclCountry.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclCountry.UpdatedAt = DateTime.Now;

            return aclCountry;
        }

       
    }
}
