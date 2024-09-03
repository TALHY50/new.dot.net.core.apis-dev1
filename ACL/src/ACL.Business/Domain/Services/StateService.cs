using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Contracts;
using MessageResponse = SharedKernel.Main.Contracts.MessageResponse;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8629 // Possible null reference argument
namespace ACL.Business.Domain.Services
{
    public class StateService : StateRepository, IStateService
    {
        /// <inheritdoc/>
        public ApplicationResponse ApplicationResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "State";
        public new static IHttpContextAccessor HttpContextAccessor;
        public StateService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
            this.ApplicationResponse = new ApplicationResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
          /// <inheritdoc/>
        public ApplicationResponse GetAll()
        {
            var aclStates = this._dbContext.AclStates
                .Join(this._dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c

                }).ToList();
            if (aclStates.Any())
            {
                this.ApplicationResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.ApplicationResponse.Data = aclStates;
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            this.ApplicationResponse.Timestamp = DateTime.Now;

            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse Add(AclStateRequest request)
        {

            var aclState = PrepareInputData(request);
            this.ApplicationResponse.Data = Add(aclState);
            this.ApplicationResponse.Message = this.MessageResponse.createMessage;
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;


        }
        /// <inheritdoc/>
        public ApplicationResponse Edit(uint id, AclStateRequest request)
        {
            var aclState = Find(id);
            if (aclState == null)
            {
                this.ApplicationResponse.Message = this.MessageResponse.notFoundMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
                return this.ApplicationResponse;
            }

            aclState = PrepareInputData(request, aclState);
            this.ApplicationResponse.Data = Update(aclState);
            this.ApplicationResponse.Message = this.MessageResponse.editMessage;
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;

        }
        /// <inheritdoc/>
        public ApplicationResponse FindById(uint id)
        {

            var aclState = All().Where(x => x.Id == id)
                .Join(this._dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c
                }).FirstOrDefault();
            this.ApplicationResponse.Data = aclState;
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            this.ApplicationResponse.Message = this.MessageResponse.fetchMessage;
            if (aclState == null)
            {
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
                this.ApplicationResponse.Message = this.MessageResponse.notFoundMessage;
            }
            this.ApplicationResponse.Timestamp = DateTime.Now;
            return this.ApplicationResponse;

        }
        /// <inheritdoc/>
        public ApplicationResponse DeleteById(uint id)
        {
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
            var aclState = Find(id);
            if (aclState != null)
            {
                this.ApplicationResponse.Data = Delete(id);
                this.ApplicationResponse.Message = this.MessageResponse.deleteMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            return this.ApplicationResponse;
        }

        private State PrepareInputData(AclStateRequest request, State? aclState = null)
        {
            if (aclState == null)
            {
                aclState = new State
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
