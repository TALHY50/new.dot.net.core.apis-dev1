
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using Microsoft.EntityFrameworkCore;

namespace ACL.Repositories
{
    public class AclCompanyModuleRepository : GenericRepository<AclCompanyModule>, IAclCompanyModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Company Module";
        public AclCompanyModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
        }
        public AclResponse FindById(ulong id)
        {
            try
            {
                var aclCompanyModule = UnitOfWork.ApplicationDbContext.AclCompanyModules.Find(id);
                aclResponse.Data = aclCompanyModule;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclCompanyModule == null)
                {
                    aclResponse.Message = messageResponse.noFoundMessage;
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

        public AclResponse AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            try
            {
                var aclCompanyModule = PrepareInputData(request);
                UnitOfWork.ApplicationDbContext.Add(aclCompanyModule);
                UnitOfWork.ApplicationDbContext.SaveChangesAsync();
                UnitOfWork.ApplicationDbContext.Entry(aclCompanyModule).ReloadAsync();
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
        public AclResponse EditAclCompanyModule(ulong Id, AclCompanyModuleRequest request)
        {
            try
            {
                var _aclCompanyModule = UnitOfWork.ApplicationDbContext.AclCompanyModules.Find(Id);
                _aclCompanyModule = PrepareInputData(request, Id, _aclCompanyModule);
                UnitOfWork.ApplicationDbContext.Update(_aclCompanyModule);
                UnitOfWork.ApplicationDbContext.SaveChangesAsync();
                UnitOfWork.ApplicationDbContext.Entry(_aclCompanyModule).ReloadAsync();
                aclResponse.Data = _aclCompanyModule;
                aclResponse.Message = messageResponse.editMessage;
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

        public AclResponse GetAll()
        {
            var aclCompanyModules = UnitOfWork.ApplicationDbContext.AclCompanyModules.ToList();
            if (aclCompanyModules.Count > 0)
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclCompanyModules;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0)
        {
            if (id == 0)
            {
                return !UnitOfWork.ApplicationDbContext.AclCompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId) && UnitOfWork.ApplicationDbContext.AclCompanies.Any(x => x.Id == companyId) && UnitOfWork.ApplicationDbContext.AclModules.Any(x => x.Id == moduleId);
            }
            else
            {
                return !UnitOfWork.ApplicationDbContext.AclCompanyModules
               .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId && x.Id != id) && UnitOfWork.ApplicationDbContext.AclCompanies.Any(x => x.Id == companyId) && UnitOfWork.ApplicationDbContext.AclModules.Any(x => x.Id == moduleId);
            }
        }

        public AclResponse DeleteCompanyModule(ulong id)
        {

            var aclCompanyModule = UnitOfWork.ApplicationDbContext.AclCompanyModules.Find(id);

            if (aclCompanyModule != null)
            {
                UnitOfWork.ApplicationDbContext.AclCompanyModules.Remove(aclCompanyModule);
                UnitOfWork.ApplicationDbContext.SaveChanges();
                aclResponse.Data = aclCompanyModule;
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;
        }

        public AclCompanyModule PrepareInputData(AclCompanyModuleRequest request, ulong Id = 0,AclCompanyModule _aclCompanyModule = null)
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
