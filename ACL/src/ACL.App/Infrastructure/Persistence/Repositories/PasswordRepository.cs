﻿using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Infrastructure.Auth.Auth;
using ACL.App.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Infrastructure.Utilities;

namespace ACL.App.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class PasswordRepository : IPasswordRepository
    {
       
        public ScopeResponse ScopeResponse;
        private readonly string _modelName = "Password";
        public readonly int TokenExpiryMinutes = 60;
        public readonly IUserRepository UserRepository;
        private readonly ICryptographyService _cryptographyService;
        public MessageResponse Response;
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        public PasswordRepository(ApplicationDbContext dbContext, ICryptographyService cryptographyService, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {

            this._dbContext = dbContext;
            this.UserRepository = userRepository;
            this._cryptographyService = cryptographyService;
            this.ScopeResponse = new ScopeResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, this._dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.Response = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
        /// <inheritdoc/>
        public async Task<ScopeResponse> Reset(AclPasswordResetRequest request)
        {
            //Auth User Id Checking
            if (AppAuth.GetAuthInfo().UserId != request.UserId)
            {
                this.ScopeResponse.Message = "Invalid User";
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
                return this.ScopeResponse;
            }

            var aclUser = this._dbContext.AclUsers.Where(x => x.Id == request.UserId && x.Status == 1).FirstOrDefault();

            if (aclUser != null)
            {
                // password checking
                var password = this._cryptographyService.HashPassword(request.CurrentPassword, aclUser.Salt);

                if (aclUser.Password != password)
                {
                    this.ScopeResponse.Message = "Password Mismatch";
                    this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
                    return this.ScopeResponse;
                }

                // password update

                aclUser.Password = this._cryptographyService.HashPassword(request.NewPassword, aclUser.Salt);
                this._dbContext.AclUsers.Update(aclUser);
                await this._dbContext.SaveChangesAsync();
                await this._dbContext.Entry(aclUser).ReloadAsync();

                this.ScopeResponse.Message = "Password Reset Succesfully.";
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;

            }

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse Forget(AclForgetPasswordRequest request)
        {
            var aclUser = this._dbContext.AclUsers.Where(x => x.Email == request.Email).FirstOrDefault();

            if (aclUser != null)
            {
                // generate unique key
                var uniqueKey = Helper.GenerateUniqueKey(aclUser.Email);

                // add to cache
                CacheHelper.Set(uniqueKey, aclUser.Email, this.TokenExpiryMinutes * 60);

                //Send Notification to email. Not implemented yet

                this.ScopeResponse.Message = "Password Reset Notification email is sent to user email";
                this.ScopeResponse.Data = uniqueKey;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public async Task<ScopeResponse> VerifyToken(AclForgetPasswordTokenVerifyRequest request)
        {
            if (!CacheHelper.Exist(request.Token))
            {
                this.ScopeResponse.Message = "Invalid Token";
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
                return this.ScopeResponse;
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
                this.ScopeResponse.Message = "Password Reset Succesfully.";
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.ScopeResponse;
        }

    }
}