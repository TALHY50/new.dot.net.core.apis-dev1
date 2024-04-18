
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;

namespace ACL.Repositories.V1
{
    public class AclSubModuleRepository : IAclSubModuleRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "SubModule";
        public AclSubModuleRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
        }

        public AclResponse GetAll()
        {
            var aclSubModules = _unitOfWork.ApplicationDbContext.AclSubModules.ToList();
            if (aclSubModules.Count > 0)
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclSubModules;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }
        public AclResponse Add(AclSubModuleRequest request)
        {
            try
            {
                var aclSubModule = PrepareInputData(request);
                _unitOfWork.ApplicationDbContext.AddAsync(aclSubModule);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclSubModule).ReloadAsync();
                aclResponse.Data = aclSubModule;
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
        public AclResponse Edit(ulong id, AclSubModuleRequest request)
        {
            var aclSubModule = _unitOfWork.ApplicationDbContext.AclSubModules.Find(id);
            if (aclSubModule == null)
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                return aclResponse;
            }
            try
            {
                aclSubModule = PrepareInputData(request, aclSubModule);

                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclSubModule).ReloadAsync();
                aclResponse.Data = aclSubModule;
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

        public AclResponse findById(ulong id)
        {
            try
            {
                var aclSubModule = _unitOfWork.ApplicationDbContext.AclSubModules.FindAsync(id);
                aclResponse.Data = aclSubModule;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclSubModule == null)
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
        public AclResponse deleteById(ulong id)
        {
            var subModule = _unitOfWork.ApplicationDbContext.AclSubModules.Find(id);

            if (subModule != null)
            {
                _unitOfWork.ApplicationDbContext.AclSubModules.Remove(subModule);
                _unitOfWork.ApplicationDbContext.SaveChanges();
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;

        }

        private AclSubModule PrepareInputData(AclSubModuleRequest request,AclSubModule aclSubModule = null)
        {
            if(aclSubModule == null)
            {
                aclSubModule = new AclSubModule();
                aclSubModule.Id = request.id;
                aclSubModule.CreatedAt = DateTime.Now;
            }
            aclSubModule.ModuleId = request.module_id;
            aclSubModule.Name = request.name;
            aclSubModule.ControllerName = request.controller_name;
            aclSubModule.DefaultMethod = request.default_method;
            aclSubModule.DisplayName = request.display_name;
            aclSubModule.Icon = request.icon;
            aclSubModule.Sequence = request.sequence;
            aclSubModule.UpdatedAt = DateTime.Now;

            return aclSubModule;
        }
    }
}
