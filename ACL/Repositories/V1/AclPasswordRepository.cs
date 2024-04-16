using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using SharedLibrary.Services;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static ACL.Route.AclRoutesName;
using static ACL.Route.AclRoutesUrl;

namespace ACL.Repositories.V1
{
    public class AclPasswordRepository : IAclPasswordRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AclResponse aclResponse;
        private string modelName = "Password";
        private ulong authUser = 2;
        private int token_expiry_time = 60;
        public AclPasswordRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            aclResponse = new AclResponse();
        }

        public AclResponse Reset(AclPasswordResetRequest request)
        {
            //Auth User Id Checking
            if (authUser != request.user_id)
            {
                aclResponse.Message = "Invalid User";
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                return aclResponse;
            }


            var aclUser =  _unitOfWork.ApplicationDbContext.AclUsers.FirstOrDefault(x=>x.Id == request.user_id && x.Status == 1);

            if (aclUser != null)
            {
                // password checking
                var currentPassword = Cryptographer.AppEncrypt(request.current_password);

                if(currentPassword != aclUser.Password)
                {
                    aclResponse.Message = "Password Mismatch";
                    aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return aclResponse;
                }

                // password update
                try
                {
                    aclUser.Password = Cryptographer.AppEncrypt(request.new_password); 
                    _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                    _unitOfWork.ApplicationDbContext.Entry(aclUser).Reload();

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

        public AclResponse Forget(AclForgetPasswordRequest request)
        {
            var aclUser = _unitOfWork.ApplicationDbContext.AclUsers.FirstOrDefault(x => x.Email == request.email);

            if (aclUser != null)
            {
                // generate unique key
                var uniqueKey = GenerateUniqueKey(aclUser.Email);

                // add to cache
                //AppCache::add(uniqueKey, request.email, token_expiry_time * 60);

                //Send Notification to email. Not implemented yet

                aclResponse.Message = "Password Reset Notification email is sent to user email";
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;
        }

        public AclResponse VerifyToken(AclForgetPasswordTokenVerifyRequest request)
        {
            throw new NotImplementedException();
        }
        private static string GenerateUniqueKey(string email)
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
