using ACL.Application.Ports.Repositories.Company;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.Company
{
    /// <inheritdoc/>
    public class AclStateRepository : IAclStateRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "State";
        /// <inheritdoc/>
        protected readonly ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclStateRepository(ApplicationDbContext dbContext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
        public AclResponse GetAll()
        {
            var aclStates = _dbContext.AclStates
                .Join(_dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c

                }).ToList();
            if (aclStates.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
            }
            this.aclResponse.Data = aclStates;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclStateRequest request)
        {

            var aclState = PrepareInputData(request);
            this.aclResponse.Data = Add(aclState);
            this.aclResponse.Message = this.messageResponse.createMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;


        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclStateRequest request)
        {
            var aclState = Find(id);
            if (aclState == null)
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                return this.aclResponse;
            }

            aclState = PrepareInputData(request, aclState);
            this.aclResponse.Data = Update(aclState);
            this.aclResponse.Message = this.messageResponse.editMessage;
            this.aclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclState = All().Where(x => x.Id == id)
                .Join(_dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c
                }).FirstOrDefault();
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
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var aclState = Find(id);
            if (aclState != null)
            {
                this.aclResponse.Data = Delete(id);
                this.aclResponse.Message = this.messageResponse.deleteMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return this.aclResponse;
        }
        /// <inheritdoc/>
        public bool ExistByName(ulong id, string name)
        {
            if (id > 0)
            {
                return _dbContext.AclStates.Any(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase) && x.Id != id);
            }
            return _dbContext.AclStates.Any(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }
        private static AclState PrepareInputData(AclStateRequest request, AclState aclState = null)
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
        /// <inheritdoc/>
        public List<AclState>? All()
        {
            try
            {
                return _dbContext.AclStates.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclState? Find(ulong id)
        {
            try
            {
                return _dbContext.AclStates.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclState? Add(AclState aclState)
        {
            try
            {
                _dbContext.AclStates.Add(aclState);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclState).Reload();
                return aclState;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclState? Update(AclState aclState)
        {
            try
            {
                _dbContext.AclStates.Update(aclState);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclState).Reload();
                return aclState;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclState? Delete(AclState aclState)
        {
            try
            {
                _dbContext.AclStates.Remove(aclState);
                _dbContext.SaveChangesAsync();
                return aclState;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclState? Delete(ulong id)
        {
            try
            {
                var delete = _dbContext.AclStates.Find(id);
                _dbContext.AclStates.Remove(delete);
                _dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
