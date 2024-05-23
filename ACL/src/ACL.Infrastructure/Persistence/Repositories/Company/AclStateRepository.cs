using ACL.Application.Ports.Repositories.Company;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Company;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            AppAuth.SetAuthInfo();
            this.AclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
            HttpContextAccessor = httpContextAccessor;
            AppAuth.Initialize(HttpContextAccessor, dbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
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
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
            }
            this.AclResponse.Data = aclStates;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            this.AclResponse.Timestamp = DateTime.Now;

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public AclResponse Add(AclStateRequest request)
        {

            var aclState = PrepareInputData(request);
            this.AclResponse.Data = Add(aclState);
            this.AclResponse.Message = this.MessageResponse.createMessage;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;


        }
        /// <inheritdoc/>
        public AclResponse Edit(ulong id, AclStateRequest request)
        {
            var aclState = Find(id);
            if (aclState == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                return this.AclResponse;
            }

            aclState = PrepareInputData(request, aclState);
            this.AclResponse.Data = Update(aclState);
            this.AclResponse.Message = this.MessageResponse.editMessage;
            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse FindById(ulong id)
        {

            var aclState = All()?.Where(x => x.Id == id)
                .Join(_dbContext.AclCountries, s => s.CountryId, c => c.Id, (s, c) => new
                {
                    state = s,
                    country = c
                }).FirstOrDefault();
            this.AclResponse.Data = aclState;
            this.AclResponse.Message = this.MessageResponse.fetchMessage;
            if (aclState == null)
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
            }

            this.AclResponse.StatusCode = AppStatusCode.SUCCESS;

            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;

        }
        /// <inheritdoc/>
        public AclResponse DeleteById(ulong id)
        {
            var aclState = Find(id);
            if (aclState != null)
            {
                this.AclResponse.Data = Delete(id);
                this.AclResponse.Message = this.MessageResponse.deleteMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            return this.AclResponse;
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
        private static AclState PrepareInputData(AclStateRequest request, AclState? aclState = null)
        {
            if (aclState == null)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                aclState = new AclState
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = AppAuth.GetAuthInfo().UserId
                };
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
