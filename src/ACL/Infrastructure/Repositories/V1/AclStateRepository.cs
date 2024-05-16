using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclStateRepository : GenericRepository<AclState>, IAclStateRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "State";
        private IAclCountryRepository AclCountryRepository;

        public AclStateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo();
            this.messageResponse = new MessageResponse(this.modelName,  AppAuth.GetAuthInfo().Language);
        }

        public async Task<AclResponse> GetAll()
        {
            var aclStates = await base.Where(s => true)
                .Join(AclCountryRepository.Where(c => true), s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c

                }).ToListAsync();
            if (aclStates.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclStates;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        public async Task<AclResponse> Add(AclStateRequest request)
        {

            var aclState = PrepareInputData(request);
            await base.AddAsync(aclState);
            await base.CompleteAsync();
            await base.ReloadAsync(aclState);
            this.aclResponse.Data = aclState;
            this.aclResponse.Message = this.messageResponse.createMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclStateRequest request)
        {
            var aclState = await base.GetById(id);
            if (aclState == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            aclState = PrepareInputData(request, aclState);
            await base.UpdateAsync(aclState);
            await base.CompleteAsync();
            await base.ReloadAsync(aclState);
            this.aclResponse.Data = aclState;
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }

        public async Task<AclResponse> FindById(ulong id)
        {

            var aclState = base.Where(s => s.Id == id)
                .Join(AclCountryRepository.Where(c => true), s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c

                }).FirstOrDefaultAsync();
            this.aclResponse.Data = aclState;
            this.aclResponse.Message = this.messageResponse.fetchMessage;
            if (aclState == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
            }

            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var aclState = await base.GetById(id);

            if (aclState != null)
            {
                await base.DeleteAsync(aclState);
                await base.CompleteAsync();
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;

        }

        private AclState PrepareInputData(AclStateRequest request, AclState aclState = null)
        {
            if (aclState == null)
            {
                aclState = new AclState();
                aclState.CreatedAt = DateTime.Now;
                aclState.CreatedById = AppAuth.GetAuthInfo().UserId;
            }
            aclState.Name = request.Name;
            aclState.CountryId = request.CountryId;
            aclState.Status = request.Status;
            aclState.Description = request.Description;
            aclState.Sequence = request.Sequence;
            aclState.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclState.UpdatedAt = DateTime.Now;

            return aclState;
        }
    }
}
