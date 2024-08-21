using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Common.Interfaces.Repositories.ACL.Auth;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Utilities;

namespace SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Auth
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
        readonly AclApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        public AclPasswordRepository(AclApplicationDbContext dbContext, ICryptographyService cryptographyService, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor)
        {

            this._dbContext = dbContext;
            this.AclUserRepository = aclUserRepository;
            this._cryptographyService = cryptographyService;
            this.AclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
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

            var aclUser = this._dbContext.AclUsers.Where(x => x.Id == request.UserId && x.Status == 1).FirstOrDefault();

            if (aclUser != null)
            {
                // password checking
                var password = this._cryptographyService.HashPassword(request.CurrentPassword, aclUser.Salt);

                if (aclUser.Password != password)
                {
                    this.AclResponse.Message = "Password Mismatch";
                    this.AclResponse.StatusCode = AppStatusCode.FAIL;
                    return this.AclResponse;
                }

                // password update

                aclUser.Password = this._cryptographyService.HashPassword(request.NewPassword, aclUser.Salt);
                this._dbContext.AclUsers.Update(aclUser);
                await this._dbContext.SaveChangesAsync();
                await this._dbContext.Entry(aclUser).ReloadAsync();

                this.AclResponse.Message = "Password Reset Succesfully.";
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            }

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Forget(AclForgetPasswordRequest request)
        {
            var aclUser = this._dbContext.AclUsers.Where(x => x.Email == request.Email).FirstOrDefault();

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

            var aclUser = this._dbContext.AclUsers?.Where(x => x.Email == email).FirstOrDefault();
            if (aclUser != null)
            {
                aclUser.Password = this._cryptographyService.HashPassword(request.NewPassword, aclUser.Salt);
                this._dbContext.AclUsers.Update(aclUser);
                await this._dbContext.SaveChangesAsync();
                await this._dbContext.Entry(aclUser).ReloadAsync();

                CacheHelper.Remove(request.Token);
                this.AclResponse.Message = "Password Reset Succesfully.";
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.AclResponse;
        }

    }
}
