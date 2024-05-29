using ACL.Application.Ports.Repositories.Company;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Infrastructure.Persistence.Repositories.Company
{
    /// <inheritdoc/>
    public class AclStateRepository : IAclStateRepository
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "State";
        /// <inheritdoc/>
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        /// <inheritdoc/>
        public AclStateRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            AclResponse = new AclResponse();
            _dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
            MessageResponse = new MessageResponse(_modelName, AppAuth.GetAuthInfo().Language);
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
                AclResponse.Message = MessageResponse.fetchMessage;
            }
            AclResponse.Data = aclStates;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;
            AclResponse.Timestamp = DateTime.Now;

            return AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclStateRequest request)
        {

            var aclState = PrepareInputData(request);
            AclResponse.Data = Add(aclState);
            AclResponse.Message = MessageResponse.createMessage;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;

            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;


        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclStateRequest request)
        {
            var aclState = Find(id);
            if (aclState == null)
            {
                AclResponse.Message = MessageResponse.notFoundMessage;
                AclResponse.StatusCode = AppStatusCode.NOTFOUND;
                return AclResponse;
            }

            aclState = PrepareInputData(request, aclState);
            AclResponse.Data = Update(aclState);
            AclResponse.Message = MessageResponse.editMessage;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;

            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;

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
            AclResponse.Data = aclState;
            AclResponse.StatusCode = AppStatusCode.SUCCESS;
            AclResponse.Message = MessageResponse.fetchMessage;
            if (aclState == null)
            {
                AclResponse.StatusCode = AppStatusCode.NOTFOUND;
                AclResponse.Message = MessageResponse.notFoundMessage;
            }
            AclResponse.Timestamp = DateTime.Now;
            return AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            AclResponse.StatusCode = AppStatusCode.NOTFOUND;
            var aclState = Find(id);
            if (aclState != null)
            {
                AclResponse.Data = Delete(id);
                AclResponse.Message = MessageResponse.deleteMessage;
                AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return AclResponse;
        }

        private AclState PrepareInputData(AclStateRequest request, AclState? aclState = null)
        {
            if (aclState == null)
            {
                aclState = new AclState
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

        /// <inheritdoc/>
        private string ExistByName(ulong? id, string name)
        {
            var valid = _dbContext.AclStates.Any(x => x.Name.ToLower() == name.ToLower());
            if (id > 0)
            {
                valid = _dbContext.AclStates.Any(x => x.Name.ToLower() == name.ToLower() && x.Id != id);
            }
            if (valid)
            {
                throw new InvalidOperationException("Name does not unique.");
            }
            return name;
        }
        /// <inheritdoc/>
        private ulong CountryIdExist(ulong countryId)
        {
            var valid = _dbContext.AclCountries.Any(x => x.Id == countryId);

            if (!valid)
            {
                throw new InvalidOperationException("Country Id does not exist.");
            }

            return countryId;
        }
        /// <inheritdoc/>
        public List<AclState> All()
        {

            return _dbContext.AclStates.ToList();

        }
        /// <inheritdoc/>
        public AclState? Find(ulong id)
        {

            return _dbContext.AclStates.Find(id);

        }
        /// <inheritdoc/>
        public AclState? Add(AclState aclState)
        {
            _dbContext.AclStates.Add(aclState);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclState).Reload();
            return aclState;
        }
        /// <inheritdoc/>
        public AclState? Update(AclState aclState)
        {

            _dbContext.AclStates.Update(aclState);
            _dbContext.SaveChanges();
            _dbContext.Entry(aclState).Reload();
            return aclState;

        }
        /// <inheritdoc/>
        public AclState? Delete(AclState aclState)
        {

            _dbContext.AclStates.Remove(aclState);
            _dbContext.SaveChangesAsync();
            return aclState;


        }
        /// <inheritdoc/>
        public AclState? Delete(ulong id)
        {

            var delete = _dbContext.AclStates.Find(id);
            _dbContext.AclStates.Remove(delete);
            _dbContext.SaveChanges();
            return delete;

        }
    }
}
