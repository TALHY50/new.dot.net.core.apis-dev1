
using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Services;
using ACL.Utilities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;
using SharedLibrary.Utilities;

namespace ACL.Repositories.V1
{
    public class AclCountryRepository : GenericRepository<AclCountry, ApplicationDbContext, ICustomUnitOfWork>, IAclCountryRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Country";
        ICustomUnitOfWork _customUnitOfWork;

        public readonly IDistributedCache _distributedCache;

        public AclCountryRepository(ICustomUnitOfWork _unitOfWork, IDistributedCache distributedCache = null) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            _customUnitOfWork = _unitOfWork;
            _distributedCache = distributedCache;
            aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {

            string? cachedCountires = await _distributedCache.GetStringAsync("countries");
            IEnumerable<AclCountry>? aclRoles;
            if (string.IsNullOrEmpty(cachedCountires))
            {
                aclRoles = await base.All();
                await _distributedCache.SetStringAsync("countries", JsonConvert.SerializeObject(aclRoles));
            }

            aclResponse.Message = messageResponse.fetchMessage;
            aclResponse.Data = JsonConvert.DeserializeObject(cachedCountires);
            aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclCountryRequest request)
        {
            try
            {
                var aclCountry = PrepareInputData(request);
                await base.AddAsync(aclCountry);
                await _unitOfWork.CompleteAsync();
                await _customUnitOfWork.AclCountryRepository.ReloadAsync(aclCountry);
                aclResponse.Data = aclCountry;
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
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
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
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

                aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = AppStatusCode.FAIL;
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
                aclResponse.StatusCode = AppStatusCode.SUCCESS;
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
            aclCountry.Name = request.Name;
            aclCountry.Description = request.Description;
            aclCountry.Code = request.Code;
            aclCountry.Status = request.Status;
            aclCountry.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclCountry.UpdatedAt = DateTime.Now;

            return aclCountry;
        }


    }
}
