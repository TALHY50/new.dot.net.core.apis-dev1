
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Utilities;
using Microsoft.Extensions.Localization;

namespace ACL.Repositories.V1
{
    public class AclRoleRepository : GenericRepository<AclRole>, IAclRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Role";
        AuthInfoModel authInfo = new AuthInfoModel(123, 456, "user@example.com", "test", "12345678", 1, "1,2");
        public AclRoleRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
            AppAuth.SetAuthInfo(authInfo);
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
                aclRole.CreatedById = AppAuth.GetAuthInfo().UserId;
                aclRole.CreatedAt = DateTime.Now;
            }
            aclRole.Title = request.title;
            aclRole.Name = request.name;
            aclRole.Status = request.status;
            aclRole.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            aclRole.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclRole.UpdatedAt = DateTime.Now;

            return aclRole;
        }

    }
}
