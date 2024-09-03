using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Infrastructure.Utilities;
using MessageResponse = SharedKernel.Main.Contracts.MessageResponse;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class PasswordRepository : IPasswordRepository
    {
       
        public ApplicationResponse ApplicationResponse;
        private readonly string _modelName = "Password";
        public readonly int TokenExpiryMinutes = 60;
        public readonly IUserRepository UserRepository;
        private readonly ICryptography _cryptography;
        public MessageResponse Response;
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        public PasswordRepository(ApplicationDbContext dbContext, ICryptography cryptography, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {

            this._dbContext = dbContext;
            this.UserRepository = userRepository;
            this._cryptography = cryptography;
            this.ApplicationResponse = new ApplicationResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.Response = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public async Task<ApplicationResponse> Reset(AclPasswordResetRequest request)
        {
            //Auth User Id Checking
            if (AppAuth.GetAuthInfo().UserId != request.UserId)
            {
                this.ApplicationResponse.Message = "Invalid User";
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                return this.ApplicationResponse;
            }

            var aclUser = this._dbContext.AclUsers.Where(x => x.Id == request.UserId && x.Status == 1).FirstOrDefault();

            if (aclUser != null)
            {
                // password checking
                var password = this._cryptography.HashPassword(request.CurrentPassword, aclUser.Salt);

                if (aclUser.Password != password)
                {
                    this.ApplicationResponse.Message = "Password Mismatch";
                    this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                    return this.ApplicationResponse;
                }

                // password update

                aclUser.Password = this._cryptography.HashPassword(request.NewPassword, aclUser.Salt);
                this._dbContext.AclUsers.Update(aclUser);
                await this._dbContext.SaveChangesAsync();
                await this._dbContext.Entry(aclUser).ReloadAsync();

                this.ApplicationResponse.Message = "Password Reset Succesfully.";
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

            }

            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse Forget(AclForgetPasswordRequest request)
        {
            var aclUser = this._dbContext.AclUsers.Where(x => x.Email == request.Email).FirstOrDefault();

            if (aclUser != null)
            {
                // generate unique key
                var uniqueKey = Helper.GenerateUniqueKey(aclUser.Email);

                // add to cache
                CacheHelper.Set(uniqueKey, aclUser.Email, this.TokenExpiryMinutes * 60);

                //Send Notification to email. Not implemented yet

                this.ApplicationResponse.Message = "Password Reset Notification email is sent to user email";
                this.ApplicationResponse.Data = uniqueKey;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }

            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public async Task<ApplicationResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request)
        {
            if (!CacheHelper.Exist(request.Token))
            {
                this.ApplicationResponse.Message = "Invalid Token";
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                return this.ApplicationResponse;
            }

            // get email from cache by token
            string email = (string)CacheHelper.Get(request.Token);
          
            // password update

            var aclUser = this._dbContext.AclUsers?.Where(x => x.Email == email).FirstOrDefault();
            if (aclUser != null)
            {
                aclUser.Password = this._cryptography.HashPassword(request.NewPassword, aclUser.Salt);
                this._dbContext.AclUsers.Update(aclUser);
                await this._dbContext.SaveChangesAsync();
                await this._dbContext.Entry(aclUser).ReloadAsync();

                CacheHelper.Remove(request.Token);
                this.ApplicationResponse.Message = "Password Reset Succesfully.";
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }

            return this.ApplicationResponse;
        }

    }
}
