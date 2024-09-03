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
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "State";
        public new static IHttpContextAccessor HttpContextAccessor;
        public StateService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
            this.ScopeResponse = new ScopeResponse();
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
        }
          /// <inheritdoc/>
        public ScopeResponse GetAll()
        {
            var aclStates = this._dbContext.AclStates
                .Join(this._dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c

                }).ToList();
            if (aclStates.Any())
            {
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.ScopeResponse.Data = aclStates;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            this.ScopeResponse.Timestamp = DateTime.Now;

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse Add(AclStateRequest request)
        {

            var aclState = PrepareInputData(request);
            this.ScopeResponse.Data = Add(aclState);
            this.ScopeResponse.Message = this.MessageResponse.createMessage;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;


        }
        /// <inheritdoc/>
        public ScopeResponse Edit(uint id, AclStateRequest request)
        {
            var aclState = Find(id);
            if (aclState == null)
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
                return this.ScopeResponse;
            }

            aclState = PrepareInputData(request, aclState);
            this.ScopeResponse.Data = Update(aclState);
            this.ScopeResponse.Message = this.MessageResponse.editMessage;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse FindById(uint id)
        {

            var aclState = All().Where(x => x.Id == id)
                .Join(this._dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c
                }).FirstOrDefault();
            this.ScopeResponse.Data = aclState;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
            if (aclState == null)
            {
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse DeleteById(uint id)
        {
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND;
            var aclState = Find(id);
            if (aclState != null)
            {
                this.ScopeResponse.Data = Delete(id);
                this.ScopeResponse.Message = this.MessageResponse.deleteMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            return this.ScopeResponse;
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
