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


namespace ACL.Repositories.V1
{
    public class AclCompanyModuleRepository : GenericRepository<AclCompanyModule,ApplicationDbContext,ICustomUnitOfWork>, IAclCompanyModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Company Module";
        public AclCompanyModuleRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork,_unitOfWork.ApplicationDbContext)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork);
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
        }
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclCompanyModule = await base.GetById(id);
                aclResponse.Data = aclCompanyModule;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclCompanyModule == null)
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
                }

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
                if (_aclCompanyModule != null)
                {
                    _aclCompanyModule = PrepareInputData(request, Id, _aclCompanyModule);
                    await base.UpdateAsync(_aclCompanyModule);
                    await _unitOfWork.CompleteAsync();
                    await base.ReloadAsync(_aclCompanyModule);
                    aclResponse.Data = _aclCompanyModule;
                    aclResponse.Message = messageResponse.editMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    aclResponse.Message = messageResponse.notFoundMessage;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            aclResponse.Timestamp = DateTime.Now;
            return aclResponse;
        }

        public async Task<AclResponse> GetAll()
        {
            var aclCompanyModules = await base.All();
            if (aclCompanyModules.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.Data = aclCompanyModules;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
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

            if (aclCompanyModule != null)
            {
                await base.DeleteAsync(aclCompanyModule);
                await _unitOfWork.CompleteAsync();
                aclResponse.Data = aclCompanyModule;
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public AclCompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong Id = 0, AclCompanyModule _aclCompanyModule = null)
        {
            bool valid = IsValidForCreateOrUpdate(request.company_id, request.module_id);
            AclCompanyModule aclCompanyModule = new AclCompanyModule();
            if (valid)
            {
                if (_aclCompanyModule != null)
                {
                    aclCompanyModule = _aclCompanyModule;
                }
                aclCompanyModule.CompanyId = request.company_id;
                aclCompanyModule.ModuleId = request.module_id;
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
