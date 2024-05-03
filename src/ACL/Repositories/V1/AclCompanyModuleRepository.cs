using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;
using ACL.Utilities;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ACL.Repositories.V1
{
    public class AclCompanyModuleRepository : GenericRepository<AclCompanyModule, ApplicationDbContext, ICustomUnitOfWork>, IAclCompanyModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Company Module";
        public AclCompanyModuleRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
             messageResponse = new MessageResponse(modelName, _unitOfWork,AppAuth.GetAuthInfo().Language);
        }
        public async Task<AclResponse> FindById(ulong id)
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


        public async Task<AclResponse> AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = PrepareInputData(request);
                Add(aclCompanyModule);
                await _unitOfWork.CompleteAsync();
                await base.ReloadAsync(aclCompanyModule);
                aclResponse.Data = aclCompanyModule;
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }
        public async Task<AclResponse> EditAclCompanyModule(ulong Id, AclCompanyModuleRequest request)
        {
            try
            {
                var _aclCompanyModule = await base.GetById(Id);
                aclResponse.Message = (_aclCompanyModule != null) ? messageResponse.editMessage : messageResponse.notFoundMessage;
                aclResponse.StatusCode = (_aclCompanyModule != null) ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
                if (_aclCompanyModule != null)
                {
                    _aclCompanyModule = PrepareInputData(request, Id, _aclCompanyModule);
                    await base.UpdateAsync(_aclCompanyModule);
                    await _unitOfWork.CompleteAsync();
                    await base.ReloadAsync(_aclCompanyModule);
                    aclResponse.Data = _aclCompanyModule;
                }
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclCompanyModules = await base.All();
            aclResponse.Message = aclCompanyModules.Any() ? messageResponse.fetchMessage : messageResponse.notFoundMessage;
            aclResponse.Data = aclCompanyModules;
            aclResponse.StatusCode = aclCompanyModules.Any() ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound;
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }


        public bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0)
        {
            if (id == 0)
            {
                return !_unitOfWork.ApplicationDbContext.AclCompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId) && _unitOfWork.ApplicationDbContext.AclCompanies.Any(x => x.Id == companyId) && _unitOfWork.ApplicationDbContext.AclModules.Any(x => x.Id == moduleId);
            }
            else
            {
                return !_unitOfWork.ApplicationDbContext.AclCompanyModules
               .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId && x.Id != id) && _unitOfWork.ApplicationDbContext.AclCompanies.Any(x => x.Id == companyId) && _unitOfWork.ApplicationDbContext.AclModules.Any(x => x.Id == moduleId);
            }
        }

        public async Task<AclResponse> DeleteCompanyModule(ulong id)
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

        public AclCompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong Id = 0, AclCompanyModule _aclCompanyModule = null)
        {
            bool valid = IsValidForCreateOrUpdate(request.CompanyId, request.ModuleId);
            AclCompanyModule aclCompanyModule = new AclCompanyModule();
            if (valid)
            {
                if (_aclCompanyModule != null)
                {
                    aclCompanyModule = _aclCompanyModule;
                }
                aclCompanyModule.CompanyId = request.CompanyId;
                aclCompanyModule.ModuleId = request.ModuleId;
                aclCompanyModule.UpdatedAt = DateTime.Now;
                if (Id == 0)
                {
                    aclCompanyModule.CreatedAt = DateTime.Now;
                }
                return aclCompanyModule;
            }
            else
            {
                throw new InvalidOperationException("Not valid data!");
            }
        }
    }
}
