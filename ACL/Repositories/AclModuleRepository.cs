using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories;
using ACL.Requests.V1;
using ACL.Response.V1;

namespace ACL.Repositories
{
    public class AclModuleRepository : GenericRepository<AclModule>, IAclModuleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Module";
        public AclModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
        }
        public AclResponse FindById(ulong id)
        {
            try
            {
                var aclModule = UnitOfWork.ApplicationDbContext.AclModules.Find(id);
                aclResponse.Data = aclModule;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclModule == null)
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

        public AclResponse AddAclModule(AclModuleRequest request)
        {
            try
            {
                var aclModule = PrepareInputData(request);
                UnitOfWork.ApplicationDbContext.Add(aclModule);
                UnitOfWork.ApplicationDbContext.SaveChangesAsync();
                UnitOfWork.ApplicationDbContext.Entry(aclModule).ReloadAsync();
                aclResponse.Data = aclModule;
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
        public AclResponse EditAclModule(ulong Id, AclModuleRequest request)
        {
            try
            {
                var aclModule = UnitOfWork.ApplicationDbContext.AclModules.Find(Id);
                aclModule = PrepareInputData(request, Id, aclModule);
                UnitOfWork.ApplicationDbContext.Update(aclModule);
                UnitOfWork.ApplicationDbContext.SaveChangesAsync();
                UnitOfWork.ApplicationDbContext.Entry(aclModule).ReloadAsync();
                aclResponse.Data = aclModule;
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
            var aclModules = UnitOfWork.ApplicationDbContext.AclModules.ToList();
            if (aclModules.Count > 0)
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclModules;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public AclResponse DeleteModule(ulong id)
        {

            var aclModule = UnitOfWork.ApplicationDbContext.AclModules.Find(id);

            if (aclModule != null)
            {
                UnitOfWork.ApplicationDbContext.AclModules.Remove(aclModule);
                UnitOfWork.ApplicationDbContext.SaveChanges();
                aclResponse.Data = aclModule;
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;
        }

        public AclModule PrepareInputData(AclModuleRequest request, ulong Id = 0, AclModule _aclModule = null)
        {
            AclModule aclModule = new AclModule();
            if (_aclModule != null)
            {
                aclModule = _aclModule;
            }
            aclModule.Id = request.id;
            aclModule.Name = request.name;
            aclModule.Icon = request.icon;
            aclModule.Sequence = request.sequence;
            aclModule.DisplayName = request.display_name;
            aclModule.UpdatedAt = DateTime.Now;
            if (_aclModule == null)
            {
                aclModule.CreatedAt = DateTime.Now;
            }
            return aclModule;

        }
    }
}
