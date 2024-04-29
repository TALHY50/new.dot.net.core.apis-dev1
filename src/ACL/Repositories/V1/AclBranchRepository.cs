using ACL.Database.Models;
using ACL.Database;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using SharedLibrary.Services;
using ACL.Response.V1;
using ACL.Utilities;
using ACL.Requests.V1;
using System.Net;

namespace ACL.Repositories.V1
{
    public class AclBranchRepository : GenericRepository<AclBranch, ApplicationDbContext, ICustomUnitOfWork>, IAclBranchRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User User Group";
        public AclBranchRepository(ICustomUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ApplicationDbContext)
        {
            AppAuth.SetAuthInfo();
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork);
        }

        Task<AclResponse> IAclBranchRepository.AddBranch(AclBranchRequest request)
        {
            throw new NotImplementedException();
        }

        async Task<AclResponse> IAclBranchRepository.DeleteById(ulong id)
        {
            var aclCompanyModule = await base.GetById(id);
            aclResponse.StatusCode = aclCompanyModule != null ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            aclResponse.Message = aclCompanyModule != null ? messageResponse.deleteMessage : messageResponse.notFoundMessage;
            aclResponse.Data = aclCompanyModule;
            if (aclCompanyModule != null)
            {
                await base.DeleteAsync(aclCompanyModule);
                await _unitOfWork.CompleteAsync();
            }
            return aclResponse;
        }

        Task<AclResponse> IAclBranchRepository.EditBranch(ulong id, AclBranchRequest request)
        {
            throw new NotImplementedException();
        }

        async Task<AclResponse> IAclBranchRepository.FindById(ulong id)
        {
            try
            {
                var aclCompanyModule = await base.GetById(id);
                var message = aclCompanyModule != null ? messageResponse.fetchMessage : messageResponse.notFoundMessage;
                aclResponse.Data = aclCompanyModule;
                aclResponse.Message = message;
                aclResponse.StatusCode = aclCompanyModule != null ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound;
                aclResponse.Timestamp = DateTime.Now;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                aclResponse.Timestamp = DateTime.Now;
            }
            return aclResponse;
        }

        async Task<AclResponse> IAclBranchRepository.GetAll()
        {
            var aclCompanyModules = await base.All();

            aclResponse.Message = aclCompanyModules.Any() ? messageResponse.fetchMessage : messageResponse.notFoundMessage;
            aclResponse.Data = aclCompanyModules;
            aclResponse.StatusCode = aclCompanyModules.Any() ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
    }
}
