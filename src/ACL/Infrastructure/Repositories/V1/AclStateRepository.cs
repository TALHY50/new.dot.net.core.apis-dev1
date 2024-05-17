
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;


namespace ACL.Infrastructure.Repositories.V1
{
    public class AclStateRepository : IAclStateRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "State";
        protected readonly ApplicationDbContext _dbContext;

        public AclStateRepository(ApplicationDbContext dbContext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo();
            this.messageResponse = new MessageResponse(this.modelName,  AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclStates = await _dbContext.AclStates
                .Join(_dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
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
            await _dbContext.AclStates.AddAsync(aclState);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(aclState).ReloadAsync();
            this.aclResponse.Data = aclState;
            this.aclResponse.Message = this.messageResponse.createMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;


        }
        public async Task<AclResponse> Edit(ulong id, AclStateRequest request)
        {
            var aclState = await _dbContext.AclStates.FindAsync(id);
            if (aclState == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            aclState = PrepareInputData(request, aclState);
             _dbContext.AclStates.Update(aclState);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(aclState).ReloadAsync();
            this.aclResponse.Data = aclState;
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }

        public async Task<AclResponse> FindById(ulong id)
        {

            var aclState = await _dbContext.AclStates.Where(x=>x.Id == id)
                .Join(_dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
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
            var aclState = await _dbContext.AclStates.FindAsync(id);

            if (aclState != null)
            {
                 _dbContext.AclStates.Remove(aclState);
                await _dbContext.SaveChangesAsync();
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }

            return this.aclResponse;

        }

        public bool ExistByName(ulong id, string name)
        {
            if(id > 0) {
                return _dbContext.AclStates.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
           return  _dbContext.AclStates.Any(x => x.Name.ToLower() == name.ToLower());
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
