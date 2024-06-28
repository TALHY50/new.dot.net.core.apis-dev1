using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Company;
using ACL.Application.Domain.Ports.Services.Company;
using ACL.Application.Infrastructure.Persistence.Configurations;
using ACL.Application.Infrastructure.Persistence.Repositories.Company;
using ACL.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Application.Infrastructure.Services.Company
{
    public class AclCountryService : AclCountryRepository, IAclCountryService
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Country";
        readonly ApplicationDbContext _dbContext;
        public new static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclCountryService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext,httpContextAccessor)
        {
            _dbContext = dbContext;
            AclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            MessageResponse = new MessageResponse(_modelName, AppAuth.GetAuthInfo().Language);
            ContextAccessor = httpContextAccessor;
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclCountry = All();
            if (aclCountry.Any())
            {
                AclResponse.Message = MessageResponse.fetchMessage;
            }
            AclResponse.Data = aclCountry;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;

            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclCountryRequest request)
        {
            try
            {
                var aclCountry = PrepareInputData(request);
                AclResponse.Data = Add(aclCountry);
                AclResponse.Message = MessageResponse.createMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return AclResponse;


        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclCountryRequest request)
        {
            var aclCountry = Find(id);
            if (aclCountry == null)
            {
                AclResponse.Message = MessageResponse.notFoundMessage;
                return AclResponse;
            }
            try
            {
                aclCountry = PrepareInputData(request, aclCountry);
                AclResponse.Data = Update(aclCountry);
                AclResponse.Message = MessageResponse.editMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                var aclCountry = Find(id);
                AclResponse.Data = aclCountry;
                AclResponse.Message = MessageResponse.fetchMessage;
                if (aclCountry == null)
                {
                    AclResponse.Message = MessageResponse.notFoundMessage;
                }

                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                AclResponse.Message = ex.Message;
                AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var aclCountry = Delete(id);
            if (aclCountry != null)
            {
                AclResponse.Data = aclCountry;
                AclResponse.Message = MessageResponse.deleteMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return AclResponse;
        }
        private AclCountry PrepareInputData(AclCountryRequest request, AclCountry? aclCountry = null)
        {
            if (aclCountry == null)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                aclCountry = new AclCountry
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
