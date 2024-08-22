﻿using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Contracts.ACL.Requests;
using SharedKernel.Main.Contracts.ACL.Response;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Domain.ACL.Domain.Company;
using SharedKernel.Main.Infrastructure.Auth;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Configurations;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Context;
using SharedKernel.Main.Infrastructure.Persistence.ACL.Repositories.Company;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8629 // Possible null reference argument
namespace SharedKernel.Main.Domain.ACL.Services.Company
{
    public class AclStateService : AclStateRepository, IAclStateService
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "State";
        public new static IHttpContextAccessor HttpContextAccessor;
        public AclStateService(AclApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
            this.AclResponse = new AclResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
          /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclStates = this._dbContext.AclStates
                .Join(this._dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c

                }).ToList();
            if (aclStates.Any())
            {
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.AclResponse.Data = aclStates;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.AclResponse.Timestamp = DateTime.Now;

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclStateRequest request)
        {

            var aclState = PrepareInputData(request);
            this.AclResponse.Data = Add(aclState);
            this.AclResponse.Message = this.MessageResponse.createMessage;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;


        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclStateRequest request)
        {
            var aclState = Find(id);
            if (aclState == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = AppStatusCode.NOTFOUND;
                return this.AclResponse;
            }

            aclState = PrepareInputData(request, aclState);
            this.AclResponse.Data = Update(aclState);
            this.AclResponse.Message = this.MessageResponse.editMessage;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclState = All().Where(x => x.Id == id)
                .Join(this._dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c
                }).FirstOrDefault();
            this.AclResponse.Data = aclState;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.AclResponse.Message = this.MessageResponse.fetchMessage;
            if (aclState == null)
            {
                this.AclResponse.StatusCode = AppStatusCode.NOTFOUND;
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            this.AclResponse.StatusCode = AppStatusCode.NOTFOUND;
            var aclState = Find(id);
            if (aclState != null)
            {
                this.AclResponse.Data = Delete(id);
                this.AclResponse.Message = this.MessageResponse.deleteMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return this.AclResponse;
        }

        private AclState PrepareInputData(AclStateRequest request, AclState? aclState = null)
        {
            if (aclState == null)
            {
                aclState = new AclState
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = AppAuth.GetAuthInfo().UserId
                };
            }
            aclState.Name = ExistByName(aclState.Id,request.Name);
            aclState.CountryId = CountryIdExist(request.CountryId);
            aclState.Status = request.Status;
            aclState.Description = request.Description;
            aclState.Sequence = request.Sequence;
            aclState.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclState.UpdatedAt = DateTime.Now;

            return aclState;
        }
    }
}
