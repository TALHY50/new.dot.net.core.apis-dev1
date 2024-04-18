
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Response.V1;

namespace ACL.Repositories.V1
{
    public class AclRoleRepository : IAclRoleRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Role";
        public AclRoleRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
        }

        public AclResponse GetAll()
        {
            var aclRoles = _unitOfWork.ApplicationDbContext.AclRoles.ToList();
            if (aclRoles.Count > 0)
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclRoles;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;

            return aclResponse;
        }
        public AclResponse Add(AclRoleRequest request)
        {
            try
            {
                var aclRole = PrepareInputData(request);
                _unitOfWork.ApplicationDbContext.AddAsync(aclRole);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclRole).ReloadAsync();
                aclResponse.Data = aclRole;
                aclResponse.Message = messageResponse.createMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return aclResponse;


        }
        public AclResponse Edit(ulong id, AclRoleRequest request)
        {
            var aclRole = _unitOfWork.ApplicationDbContext.AclRoles.Find(id);
            if (aclRole == null)
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                return aclResponse;
            }
            try
            {
                aclRole = PrepareInputData(request, aclRole);
                _unitOfWork.ApplicationDbContext.SaveChangesAsync();
                _unitOfWork.ApplicationDbContext.Entry(aclRole).Reload();
                aclResponse.Data = aclRole;
                aclResponse.Message = messageResponse.editMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                aclResponse.Message = ex.Message;
                aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return aclResponse;

        }
        public AclResponse findById(ulong id)
        {
            try
            {
                var aclRole = _unitOfWork.ApplicationDbContext.AclRoles.Find(id);
                aclResponse.Data = aclRole;
                aclResponse.Message = messageResponse.fetchMessage;
                if (aclRole == null)
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
            return aclResponse;

        }
        public AclResponse deleteById(ulong id)
        {
            var aclRole = _unitOfWork.ApplicationDbContext.AclRoles.Find(id);

            if (aclRole != null)
            {
                _unitOfWork.ApplicationDbContext.AclRoles.Remove(aclRole);
                _unitOfWork.ApplicationDbContext.SaveChanges();
                aclResponse.Message = messageResponse.deleteMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }

            return aclResponse;

        }
        private AclRole PrepareInputData(AclRoleRequest request, AclRole aclRole = null)
        {
            if (aclRole == null)
            {
                aclRole = new AclRole();
                aclRole.CreatedById = 0;
                aclRole.CreatedAt = DateTime.Now;
            }
            aclRole.Title = request.title;
            aclRole.Name = request.name;
            aclRole.Status = request.status;
            aclRole.CompanyId = 1;
            aclRole.UpdatedById = 0;
            aclRole.UpdatedAt = DateTime.Now;

            return aclRole;
        }


    }
}
