using ACL.Application.Interfaces.Repositories.V1;
using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Utilities;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclPasswordRepository :  IAclPasswordRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        private string modelName = "Password";
        private int tokenExpiryMinutes = 60;
        private IAclUserRepository AclUserRepository;
        private ICryptographyService cryptographyService;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclPasswordRepository(ApplicationDbContext dbContext,ICryptographyService _cryptographyService,IAclUserRepository _AclUserRepository) 
        {
            AclUserRepository = _AclUserRepository;
            cryptographyService = _cryptographyService;
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> Reset(AclPasswordResetRequest request)
        {
            //Auth User Id Checking
            if (AppAuth.GetAuthInfo().UserId != request.UserId)
            {
                this.aclResponse.Message = "Invalid User";
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
                return this.aclResponse;
            }


            var aclUser = _dbContext.AclUsers.Where(x => x.Id == request.UserId && x.Status == 1).FirstOrDefault();

            if (aclUser != null)
            {
                // password checking
                var password = cryptographyService.HashPassword(request.CurrentPassword,aclUser.Salt);

                if (request.CurrentPassword != password)
                {
                    this.aclResponse.Message = "Password Mismatch";
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                    return this.aclResponse;
                }

                // password update

                aclUser.Password = cryptographyService.HashPassword(request.NewPassword,aclUser.Salt);
                 _dbContext.AclUsers.Update(aclUser);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Entry(aclUser).ReloadAsync();

                this.aclResponse.Message = "Password Reset Succesfully.";
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            }

            return this.aclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> Forget(AclForgetPasswordRequest request)
        {
            var aclUser = _dbContext.AclUsers.Where(x => x.Email == request.Email).FirstOrDefault();

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
        /// <inheritdoc/>
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

            var aclUser = _dbContext.AclUsers.Where(x => x.Email == email).FirstOrDefault();
            if (aclUser != null)
            {
                aclUser.Password = cryptographyService.HashPassword(request.NewPassword,aclUser.Salt);
                 _dbContext.AclUsers.Update(aclUser);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Entry(aclUser).ReloadAsync();

                CacheHelper.Remove(request.Token);
                this.aclResponse.Message = "Password Reset Succesfully.";
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;
        }

    }
}
