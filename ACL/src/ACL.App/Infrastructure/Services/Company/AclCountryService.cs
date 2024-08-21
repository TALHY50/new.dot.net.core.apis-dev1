using ACL.App.Application.Interfaces.Services.Company;
using ACL.App.Infrastructure.Persistence.Configurations;
using ACL.App.Infrastructure.Persistence.Repositories.Company;
using ACL.App.Infrastructure.Utilities;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;
using SharedKernel.Main.Domain.ACL.Domain.Company;

namespace ACL.App.Infrastructure.Services.Company
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
            this._dbContext = dbContext;
            this.AclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            ContextAccessor = httpContextAccessor;
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclCountry = All();
            if (aclCountry.Any())
            {
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.AclResponse.Data = aclCountry;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclCountryRequest request)
        {
            try
            {
                var aclCountry = PrepareInputData(request);
                this.AclResponse.Data = Add(aclCountry);
                this.AclResponse.Message = this.MessageResponse.createMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.AclResponse;


        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclCountryRequest request)
        {
            var aclCountry = Find(id);
            if (aclCountry == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                return this.AclResponse;
            }
            try
            {
                aclCountry = PrepareInputData(request, aclCountry);
                this.AclResponse.Data = Update(aclCountry);
                this.AclResponse.Message = this.MessageResponse.editMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {
            try
            {
                var aclCountry = Find(id);
                this.AclResponse.Data = aclCountry;
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
                if (aclCountry == null)
                {
                    this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                }

                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var aclCountry = Delete(id);
            if (aclCountry != null)
            {
                this.AclResponse.Data = aclCountry;
                this.AclResponse.Message = this.MessageResponse.deleteMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return this.AclResponse;
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
