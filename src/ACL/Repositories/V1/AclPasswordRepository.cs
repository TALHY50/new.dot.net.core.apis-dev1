using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Utilities;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using SharedLibrary.Utilities;



namespace ACL.Repositories.V1
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
            _customUnitOfWork = _unitOfWork;
            aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> Reset(AclPasswordResetRequest request)
        {
            //Auth User Id Checking
            if (AppAuth.GetAuthInfo().UserId != request.UserId)
            {
                aclResponse.Message = "Invalid User";
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return aclResponse;
            }


            var aclUser = _customUnitOfWork.AclUserRepository.Where(x => x.Id == request.UserId && x.Status == 1).FirstOrDefault();

            if (aclUser != null)
            {
                // password checking
                var password = Cryptographer.AppDecrypt(aclUser.Password);

                if (request.CurrentPassword != password)
                {
                    aclResponse.Message = "Password Mismatch";
                    aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return aclResponse;
                }

                // password update

                aclUser.Password = Cryptographer.AppEncrypt(request.NewPassword);
                await base.UpdateAsync(aclUser);
                await _unitOfWork.CompleteAsync();
                await _customUnitOfWork.AclUserRepository.ReloadAsync(aclUser);

                aclResponse.Message = "Password Reset Succesfully.";
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;

            }

            return aclResponse;
        }

        public async Task<AclResponse> Forget(AclForgetPasswordRequest request)
        {
            var aclUser = _customUnitOfWork.AclUserRepository.Where(x => x.Email == request.Email).FirstOrDefault();

            if (aclUser != null)
            {
                // generate unique key
                var uniqueKey = Helper.GenerateUniqueKey(aclUser.Email);

                // add to cache
                CacheHelper.Set(uniqueKey, aclResponse.Data, tokenExpiryMinutes * 60);

                //Send Notification to email. Not implemented yet

                aclResponse.Message = "Password Reset Notification email is sent to user email";
                aclResponse.Data = uniqueKey;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;
        }

        public async Task<AclResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request)
        {
            if (!CacheHelper.Exist(request.Token))
            {
                aclResponse.Message = "Invalid Token";
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return aclResponse;
            }

            // get email from cache by token
            string email = (string)CacheHelper.Get(request.Token);

            // password update

            var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.Where(x => x.Email == email).FirstOrDefault();
            aclUser.Password = Cryptographer.AppEncrypt(request.NewPassword);
            await base.UpdateAsync(aclUser);
            await _unitOfWork.CompleteAsync();
            await _customUnitOfWork.AclUserRepository.ReloadAsync(aclUser);

            CacheHelper.Remove(request.Token);
            aclResponse.Message = "Password Reset Succesfully.";
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;

            return aclResponse;
        }

    }
}
