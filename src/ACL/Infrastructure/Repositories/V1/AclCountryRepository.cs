using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using ACL.Requests;
using ACL.Response.V1;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclCountryRepository : GenericRepository<AclCountry, ApplicationDbContext, ICustomUnitOfWork>, IAclCountryRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Country";
        ICustomUnitOfWork _customUnitOfWork;

        public AclCountryRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            this._customUnitOfWork = _unitOfWork;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclRoles = await base.All();
            if (aclRoles.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclRoles;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.aclResponse;
        }
        public async Task<AclResponse> Add(AclCountryRequest request)
        {
            try
            {
                var aclCountry = PrepareInputData(request);
                await base.AddAsync(aclCountry);
                await this._unitOfWork.CompleteAsync();
                await this._customUnitOfWork.AclCountryRepository.ReloadAsync(aclCountry);
                this.aclResponse.Data = aclCountry;
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclCountryRequest request)
        {
            var aclCountry = await base.GetById(id);
            if (aclCountry == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }
            try
            {
                aclCountry = PrepareInputData(request, aclCountry);
                await base.UpdateAsync(aclCountry);
                await this._unitOfWork.CompleteAsync();
                await this._unitOfWork.AclCountryRepository.ReloadAsync(aclCountry);
                this.aclResponse.Data = aclCountry;
                this.aclResponse.Message = this.messageResponse.editMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;

        }
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclRole = await base.GetById(id);
                this.aclResponse.Data = aclRole;
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                if (aclRole == null)
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
            return this.aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var aclRole = await base.GetById(id);

            if (aclRole != null)
            {
                await base.DeleteAsync(aclRole);
                await this._unitOfWork.CompleteAsync();
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;

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
