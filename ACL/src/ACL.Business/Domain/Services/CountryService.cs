using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Contracts;
using MessageResponse = SharedKernel.Main.Contracts.MessageResponse;

namespace ACL.Business.Domain.Services
{
    public class CountryService : CountryRepository, ICountryService
    {
        /// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Country";
        readonly ApplicationDbContext _dbContext;
        public new static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public CountryService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext,httpContextAccessor)
        {
            this._dbContext = dbContext;
            this.ScopeResponse = new ScopeResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            ContextAccessor = httpContextAccessor;
        }
        /// <inheritdoc/>
        public ScopeResponse GetAll()
        {
            var aclCountry = All();
            if (aclCountry.Any())
            {
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.ScopeResponse.Data = aclCountry;
            this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public ScopeResponse Add(AclCountryRequest request)
        {
            try
            {
                var aclCountry = PrepareInputData(request);
                this.ScopeResponse.Data = Add(aclCountry);
                this.ScopeResponse.Message = this.MessageResponse.createMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            return this.ScopeResponse;


        }
        /// <inheritdoc/>
        public ScopeResponse Edit(uint id, AclCountryRequest request)
        {
            var aclCountry = Find(id);
            if (aclCountry == null)
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                return this.ScopeResponse;
            }
            try
            {
                aclCountry = PrepareInputData(request, aclCountry);
                this.ScopeResponse.Data = Update(aclCountry);
                this.ScopeResponse.Message = this.MessageResponse.editMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse FindById(uint id)
        {
            try
            {
                var aclCountry = Find(id);
                this.ScopeResponse.Data = aclCountry;
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
                if (aclCountry == null)
                {
                    this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                }

                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            return this.ScopeResponse;

        }
        /// <inheritdoc/>
        public ScopeResponse DeleteById(uint id)
        {
            var aclCountry = Delete(id);
            if (aclCountry != null)
            {
                this.ScopeResponse.Data = aclCountry;
                this.ScopeResponse.Message = this.MessageResponse.deleteMessage;
                this.ScopeResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            return this.ScopeResponse;
        }
        private Country PrepareInputData(AclCountryRequest request, Country? aclCountry = null)
        {
            if (aclCountry == null)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                aclCountry = new Country
                {
                    CreatedById = AppAuth.GetAuthInfo().UserId,
                    CreatedAt = DateTime.Now
                };
            }
            aclCountry.Name = request.Name;
            aclCountry.Description = request.Description;
            aclCountry.Code = request.Code;
            aclCountry.Status = request.Status;
            aclCountry.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclCountry.UpdatedAt = DateTime.Now;
            return aclCountry;
        }
    }
}
