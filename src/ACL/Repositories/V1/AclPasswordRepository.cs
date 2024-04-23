using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Utilities;
using Microsoft.Extensions.Localization;
using SharedLibrary.Services;
using SharedLibrary.Utilities;
using System.Security.Cryptography;
using System.Text;


namespace ACL.Repositories.V1
{
    public class AclPasswordRepository : GenericRepository<AclUser>, IAclPasswordRepository
    {
        public AclResponse aclResponse;
        private string modelName = "Password";
        private int tokenExpiryMinutes = 60;
        public MessageResponse messageResponse;
        IStringLocalizer<AclUser> _localizer;
        public AclPasswordRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
        }

        public async Task<AclResponse> Reset(AclPasswordResetRequest request)
        {
            //Auth User Id Checking
            if (AppAuth.GetAuthInfo().UserId != request.user_id)
            {
                aclResponse.Message = "Invalid User";
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return aclResponse;
            }


            var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.FirstOrDefault(x => x.Id == request.user_id && x.Status == 1);

            if (aclUser != null)
            {
                // password checking
                var password = Cryptographer.AppDecrypt(aclUser.Password);


                if (request.current_password != password)
                {
                    aclResponse.Message = "Password Mismatch";
                    aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return aclResponse;
                }

                // password update
                try
                {
                    aclUser.Password = Cryptographer.AppEncrypt(request.new_password);
                    await base.UpdateAsync(aclUser);
                    await _unitOfWork.CompleteAsync();
                    await _unitOfWork.AclUserRepository.ReloadAsync(aclUser);
                  
                    aclResponse.Message = "Password Reset Succesfully.";
                    aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    aclResponse.Message = ex.Message;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }

            return aclResponse;
        }

        public async Task<AclResponse> Forget(AclForgetPasswordRequest request)
        {
            var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.FirstOrDefault(x => x.Email == request.email);

            if (aclUser != null)
            {
                // generate unique key
                var uniqueKey = GenerateUniqueKey(aclUser.Email);

                // add to cache
                //MemoryCaches(uniqueKey, request.email, tokenExpiryMinutes * 60);
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
            if (!CacheHelper.Exist(request.token))
            {
                aclResponse.Message = "Invalid Token";
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return aclResponse;
            }

            // get email from cache by token
            string email = (string)CacheHelper.Get(request.token);

            // password update
            try
            {
                var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.FirstOrDefault(x => x.Email == email);
                aclUser.Password = Cryptographer.AppEncrypt(request.new_password);
                await base.UpdateAsync(aclUser);
                await _unitOfWork.CompleteAsync();
                await _unitOfWork.AclUserRepository.ReloadAsync(aclUser);

                CacheHelper.Remove(request.token);
                aclResponse.Message = "Password Reset Succesfully.";
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }

            return aclResponse;

        }
        private string GenerateUniqueKey(string email)
        {
            // Hash the email address using SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(email));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

       

    }
}
