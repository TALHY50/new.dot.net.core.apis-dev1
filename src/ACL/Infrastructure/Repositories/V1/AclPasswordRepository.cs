using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;
using SharedLibrary.Utilities;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclPasswordRepository : GenericRepository<AclUser, ApplicationDbContext, ICustomUnitOfWork>, IAclPasswordRepository
    {
        public AclResponse aclResponse;
        private string modelName = "Password";
        private int tokenExpiryMinutes = 60;
        public MessageResponse messageResponse;
        private ICustomUnitOfWork _customUnitOfWork;
        public AclPasswordRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            this._customUnitOfWork = _unitOfWork;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> Reset(AclPasswordResetRequest request)
        {
            //Auth User Id Checking
            if (AppAuth.GetAuthInfo().UserId != request.UserId)
            {
                this.aclResponse.Message = "Invalid User";
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
                return this.aclResponse;
            }


            var aclUser = this._customUnitOfWork.AclUserRepository.Where(x => x.Id == request.UserId && x.Status == 1).FirstOrDefault();

            if (aclUser != null)
            {
                // password checking
                var password = this._unitOfWork.cryptographyService.HashPassword(request.CurrentPassword,aclUser.Salt);

                if (request.CurrentPassword != password)
                {
                    this.aclResponse.Message = "Password Mismatch";
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                    return this.aclResponse;
                }

                // password update

                aclUser.Password = this._unitOfWork.cryptographyService.HashPassword(request.NewPassword,aclUser.Salt);
                await base.UpdateAsync(aclUser);
                await this._unitOfWork.CompleteAsync();
                await this._customUnitOfWork.AclUserRepository.ReloadAsync(aclUser);

                this.aclResponse.Message = "Password Reset Succesfully.";
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            }

            return this.aclResponse;
        }

        public async Task<AclResponse> Forget(AclForgetPasswordRequest request)
        {
            var aclUser = this._customUnitOfWork.AclUserRepository.Where(x => x.Email == request.Email).FirstOrDefault();

            if (aclUser != null)
            {
                // generate unique key
                var uniqueKey = Helper.GenerateUniqueKey(aclUser.Email);

                // add to cache
                CacheHelper.Set(uniqueKey, aclUser.Email, this.tokenExpiryMinutes * 60);

                //Send Notification to email. Not implemented yet

                this.aclResponse.Message = "Password Reset Notification email is sent to user email";
                this.aclResponse.Data = uniqueKey;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;
        }

        public async Task<AclResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request)
        {
            if (!CacheHelper.Exist(request.Token))
            {
                this.aclResponse.Message = "Invalid Token";
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
                return this.aclResponse;
            }

            // get email from cache by token
            string  email = (string)CacheHelper.Get(request.Token);

            // password update

            var aclUser = this._unitOfWork.AclUserRepository.Where(x => x.Email == email).FirstOrDefault();
            if (aclUser != null)
            {
                aclUser.Password = this._unitOfWork.cryptographyService.HashPassword(request.NewPassword,aclUser.Salt);
                await base.UpdateAsync(aclUser);
                await this._unitOfWork.CompleteAsync();
                await this._customUnitOfWork.AclUserRepository.ReloadAsync(aclUser);

                CacheHelper.Remove(request.Token);
                this.aclResponse.Message = "Password Reset Succesfully.";
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;
        }

    }
}
