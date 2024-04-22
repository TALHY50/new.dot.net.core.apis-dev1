﻿
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Utilities;

namespace ACL.Repositories.V1
{
    public class AclRoleRepository : GenericRepository<AclRole>, IAclRoleRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Role";
        public AclRoleRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName);
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
        }

        public async Task<AclResponse> GetAll()
        {
            var aclRoles = await base.All();
            if (aclRoles.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
            }
            aclResponse.Data = aclRoles;
            aclResponse.StatusCode = System.Net.HttpStatusCode.OK;

            return aclResponse;
        }
        public async Task<AclResponse> Add(AclRoleRequest request)
        {
            try
            {
                var aclRole = PrepareInputData(request);
                await base.AddAsync(aclRole);
                await _unitOfWork.CompleteAsync();
                await _unitOfWork.AclRoleRepository.ReloadAsync(aclRole);
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
        public async Task<AclResponse> Edit(ulong id, AclRoleRequest request)
        {
            var aclRole = await base.GetById(id);
            if (aclRole == null)
            {
                aclResponse.Message = messageResponse.noFoundMessage;
                return aclResponse;
            }
            try
            {
                aclRole = PrepareInputData(request, aclRole);
                await base.UpdateAsync(aclRole);
                await _unitOfWork.CompleteAsync();
                await _unitOfWork.AclRoleRepository.ReloadAsync(aclRole);
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
        public async Task<AclResponse> FindById(ulong id)
        {
            try
            {
                var aclRole = await base.GetById(id);
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
        public async Task<AclResponse> DeleteById(ulong id)
        {
            var aclRole = await base.GetById(id);

            if (aclRole != null)
            {
                await base.DeleteAsync(aclRole);
                await _unitOfWork.CompleteAsync();
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
