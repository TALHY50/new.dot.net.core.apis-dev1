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
        public ApplicationResponse ApplicationResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Country";
        readonly ApplicationDbContext _dbContext;
        public new static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public CountryService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext,httpContextAccessor)
        {
            this._dbContext = dbContext;
            this.ApplicationResponse = new ApplicationResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            ContextAccessor = httpContextAccessor;
        }
        /// <inheritdoc/>
        public ApplicationResponse GetAll()
        {
            var aclCountry = All();
            if (aclCountry.Any())
            {
                this.ApplicationResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.ApplicationResponse.Data = aclCountry;
            this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;

            return this.ApplicationResponse;
        }
        /// <inheritdoc/>
        public ApplicationResponse Add(AclCountryRequest request)
        {
            try
            {
                var aclCountry = PrepareInputData(request);
                this.ApplicationResponse.Data = Add(aclCountry);
                this.ApplicationResponse.Message = this.MessageResponse.createMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            return this.ApplicationResponse;


        }
        /// <inheritdoc/>
        public ApplicationResponse Edit(uint id, AclCountryRequest request)
        {
            var aclCountry = Find(id);
            if (aclCountry == null)
            {
                this.ApplicationResponse.Message = this.MessageResponse.notFoundMessage;
                return this.ApplicationResponse;
            }
            try
            {
                aclCountry = PrepareInputData(request, aclCountry);
                this.ApplicationResponse.Data = Update(aclCountry);
                this.ApplicationResponse.Message = this.MessageResponse.editMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            return this.ApplicationResponse;

        }
        /// <inheritdoc/>
        public ApplicationResponse FindById(uint id)
        {
            try
            {
                var aclCountry = Find(id);
                this.ApplicationResponse.Data = aclCountry;
                this.ApplicationResponse.Message = this.MessageResponse.fetchMessage;
                if (aclCountry == null)
                {
                    this.ApplicationResponse.Message = this.MessageResponse.notFoundMessage;
                }

                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            catch (Exception ex)
            {
                this.ApplicationResponse.Message = ex.Message;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
            }
            return this.ApplicationResponse;

        }
        /// <inheritdoc/>
        public ApplicationResponse DeleteById(uint id)
        {
            var aclCountry = Delete(id);
            if (aclCountry != null)
            {
                this.ApplicationResponse.Data = aclCountry;
                this.ApplicationResponse.Message = this.MessageResponse.deleteMessage;
                this.ApplicationResponse.StatusCode = ApplicationStatusCodes.API_SUCCESS;
            }
            return this.ApplicationResponse;
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
