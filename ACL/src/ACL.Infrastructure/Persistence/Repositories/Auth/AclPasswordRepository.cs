using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Services;
using ACL.Application.Ports.Services.Cryptography;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Utilities;

namespace ACL.Infrastructure.Persistence.Repositories.Auth
{
    /// <inheritdoc/>
    public class AclPasswordRepository : IAclPasswordRepository
    {
       
        public AclResponse AclResponse;
        private readonly string _modelName = "Password";
        public readonly int TokenExpiryMinutes = 60;
        public readonly IAclUserRepository AclUserRepository;
        private readonly ICryptographyService _cryptographyService;
        public MessageResponse Response;
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        public AclPasswordRepository(ApplicationDbContext dbContext, ICryptographyService cryptographyService, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {

            _dbContext = dbContext;
            AclUserRepository = aclUserRepository;
            this._cryptographyService = cryptographyService;
            this.AclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, _dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.Response = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public async Task<AclResponse> Reset(AclPasswordResetRequest request)
        {
            //Auth User Id Checking
            if (AppAuth.GetAuthInfo().UserId != request.UserId)
            {
                this.AclResponse.Message = "Invalid User";
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
                return this.AclResponse;
            }

            var aclUser = _dbContext.AclUsers.Where(x => x.Id == request.UserId && x.Status == 1).FirstOrDefault();

            if (aclUser != null)
            {
                // password checking
                var password = _cryptographyService.HashPassword(request.CurrentPassword, aclUser.Salt);

                if (aclUser.Password != password)
                {
                    this.AclResponse.Message = "Password Mismatch";
                    this.AclResponse.StatusCode = AppStatusCode.FAIL;
                    return this.AclResponse;
                }

                // password update

                aclUser.Password = _cryptographyService.HashPassword(request.NewPassword, aclUser.Salt);
                _dbContext.AclUsers.Update(aclUser);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Entry(aclUser).ReloadAsync();

                this.AclResponse.Message = "Password Reset Succesfully.";
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            }

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Forget(AclForgetPasswordRequest request)
        {
            var aclUser = _dbContext.AclUsers.Where(x => x.Email == request.Email).FirstOrDefault();

            if (aclUser != null)
            {
                // generate unique key
                var uniqueKey = Helper.GenerateUniqueKey(aclUser.Email);

                // add to cache
                CacheHelper.Set(uniqueKey, aclUser.Email, this.TokenExpiryMinutes * 60);

                //Send Notification to email. Not implemented yet

                this.AclResponse.Message = "Password Reset Notification email is sent to user email";
                this.AclResponse.Data = uniqueKey;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request)
        {
            if (!CacheHelper.Exist(request.Token))
            {
                this.AclResponse.Message = "Invalid Token";
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
                return this.AclResponse;
            }

            // get email from cache by token
            string email = (string)CacheHelper.Get(request.Token);
          
            // password update

            var aclUser = _dbContext.AclUsers?.Where(x => x.Email == email).FirstOrDefault();
            if (aclUser != null)
            {
                aclUser.Password = _cryptographyService.HashPassword(request.NewPassword, aclUser.Salt);
                _dbContext.AclUsers.Update(aclUser);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Entry(aclUser).ReloadAsync();

                CacheHelper.Remove(request.Token);
                this.AclResponse.Message = "Password Reset Succesfully.";
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.AclResponse;
        }

    }
}
