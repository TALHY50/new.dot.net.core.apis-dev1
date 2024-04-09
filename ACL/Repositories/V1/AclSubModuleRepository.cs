
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
                var aclSubModule = prepareInputData(request);
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
            try
            {
                var aclSubModule = prepareInputData(request);
                _unitOfWork.ApplicationDbContext.Update(aclSubModule);
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

        private AclSubModule prepareInputData(AclSubModuleRequest request)
        {
            return new AclSubModule
            {
                Id = request.id,
                ModuleId = request.module_id,
                Name = request.name,
                ControllerName = request.controller_name,
                DefaultMethod = request.default_method,
                DisplayName = request.display_name,
                Icon = request.icon,
                Sequence = request.sequence,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

        }
    }
}
