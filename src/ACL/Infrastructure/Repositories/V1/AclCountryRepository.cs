using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclCountryRepository : GenericRepository<AclCountry>, IAclCountryRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Country";

        public AclCountryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclRoles = await base.All();
            if (aclRoles.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclRoles;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            return this.aclResponse;
        }
        public async Task<AclResponse> Add(AclCountryRequest request)
        {
            try
            {
                var aclCountry = PrepareInputData(request);
                await base.AddAsync(aclCountry);
                await base.CompleteAsync();
                await base.ReloadAsync(aclCountry);
                this.aclResponse.Data = aclCountry;
                this.aclResponse.Message = this.messageResponse.createMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclCountryRequest request)
        {
            var aclCountry = await base.GetById(id);
            if (aclCountry == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }
            try
            {
                aclCountry = PrepareInputData(request, aclCountry);
                await base.UpdateAsync(aclCountry);
                await base.CompleteAsync();
                await base.ReloadAsync(aclCountry);
                this.aclResponse.Data = aclCountry;
                this.aclResponse.Message = this.messageResponse.editMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;

        }
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclRole = await base.GetById(id);
                this.aclResponse.Data = aclRole;
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                if (aclRole == null)
                {
                    this.aclResponse.Message = this.messageResponse.notFoundMessage;
                }

                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            return this.aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var aclRole = await base.GetById(id);

            if (aclRole != null)
            {
                await base.DeleteAsync(aclRole);
                await base.CompleteAsync();
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;

        }
        private AclCountry PrepareInputData(AclCountryRequest request, AclCountry aclCountry = null)
        {
            if (aclCountry == null)
            {
                aclCountry = new AclCountry();
                aclCountry.CreatedById = AppAuth.GetAuthInfo().UserId;
                aclCountry.CreatedAt = DateTime.Now;
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
