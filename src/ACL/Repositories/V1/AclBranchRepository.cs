using ACL.Database.Models;
using ACL.Database;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using SharedLibrary.Services;
using ACL.Response.V1;
using ACL.Utilities;
using ACL.Requests.V1;
using System.Net;
using Castle.Components.DictionaryAdapter.Xml;

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

        async Task<AclResponse> IAclBranchRepository.AddBranch(AclBranchRequest request)
        {
            try
            {
                AclBranch _aclBranch = PrepareInputData(request);
                await base.AddAsync(_aclBranch);
                await _unitOfWork.CompleteAsync();
                await base.ReloadAsync(_aclBranch);
                aclResponse.Data = _aclBranch;
                aclResponse.Message = _aclBranch != null ? messageResponse.createMessage : messageResponse.notFoundMessage;

                aclResponse.StatusCode = _aclBranch != null ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            }
            catch (Exception ex)
            {
                _unitOfWork.Logger.LogError(ex, "Error at BRANCH_ADD", new { data = request, message = ex.Message, });
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
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

        async Task<AclResponse> IAclBranchRepository.EditBranch(ulong id, AclBranchRequest request)
        {
            try
            {
                var _aclBranch = await base.GetById(id);
                _aclBranch = PrepareInputData(request, _aclBranch);
                await base.UpdateAsync(_aclBranch);
                await _unitOfWork.CompleteAsync();
                await base.ReloadAsync(_aclBranch);
                aclResponse.Data = _aclBranch;
                aclResponse.Message = _aclBranch != null ? messageResponse.editMessage : messageResponse.notFoundMessage;

                aclResponse.StatusCode = _aclBranch != null ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            }
            catch (Exception ex)
            {
                _unitOfWork.Logger.LogError(ex, "Error at BRANCH_EDIT", new { data = request, message = ex.Message, });
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
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

        private AclBranch PrepareInputData(AclBranchRequest request, AclBranch aclBranch=null)
        {
            AclBranch _aclBranch = aclBranch ?? new AclBranch();
            _aclBranch.Name = request.Name;
            _aclBranch.Address = request.Address;
            _aclBranch.Description = request.Description;
            _aclBranch.Sequence = request.Sequence;
            _aclBranch.Status = (byte)(request.Status ?? 1);
            _aclBranch.UpdatedAt = DateTime.Now;
            _aclBranch.UpdatedById = AppAuth.GetAuthInfo().UserId;
            _aclBranch.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            if(aclBranch == null)
            {
                _aclBranch.CreatedAt = DateTime.Now;
                _aclBranch.CreatedById = AppAuth.GetAuthInfo().UserId;
            }
            return _aclBranch;
        }
    }
}
