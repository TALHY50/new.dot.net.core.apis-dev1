using ACL.Application.Contracts.Requests;
using ACL.Application.Contracts.Response;
using ACL.Application.Domain.Company;
using ACL.Application.Domain.Ports.Services.Company;
using ACL.Application.Infrastructure.Persistence.Configurations;
using ACL.Application.Infrastructure.Persistence.Repositories.Company;
using ACL.Application.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Response.CustomStatusCode;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8629 // Possible null reference argument
namespace ACL.Application.Infrastructure.Services.Company
{
    public class AclStateService : AclStateRepository, IAclStateService
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "State";
        public new static IHttpContextAccessor HttpContextAccessor;
        public AclStateService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext, httpContextAccessor)
        {
            AclResponse = new AclResponse();
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
    }
}
