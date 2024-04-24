using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Response.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Linq;
using static ACL.Route.AclRoutesUrl;

namespace ACL.Repositories.V1
{
    public class AclRolePageRepository : GenericRepository<Database.Models.AclRolePage>, IAclRolePageRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Role Page";
        public AclRolePageRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork);
        }

        public async Task<AclResponse> GetAllById(ulong id)
        {
            var res = await base.Where(x => x.RoleId == id).ToListAsync();
            if (res.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            aclResponse.Data = res;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }

        public async Task<AclResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest req)
        {
            var res = await base.Where(x => x.RoleId == req.role_id).ToListAsync();
            var check = PrepareData(req);
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var removedEntities = await base.RemoveRange(res);
                    await base.AddRange(check);
                    await _unitOfWork.CommitTransactionAsync();
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    aclResponse.Message = ex.Message;
                    aclResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            await _unitOfWork.CompleteAsync();
            await ReloadEntitiesAsync(check);
            res = check.ToList();
            if (res.Any())
            {
                aclResponse.Message = messageResponse.fetchMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                aclResponse.Message = messageResponse.notFoundMessage;
                aclResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }

            aclResponse.Data = res;
            aclResponse.Timestamp = DateTime.Now;

            return aclResponse;
        }


        public Database.Models.AclRolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest req)
        {
            IList<Database.Models.AclRolePage> res = new List<Database.Models.AclRolePage>();
            foreach (ulong page in req.PageIds)
            {
                bool exists = res.Any(r => r.RoleId == page);
                if (!exists)
                {
                    Database.Models.AclRolePage aclRolePage = new Database.Models.AclRolePage();
                    aclRolePage.Id = 0;
                    aclRolePage.RoleId = req.role_id;
                    aclRolePage.PageId = page;
                    aclRolePage.CreatedAt = DateTime.Now;
                    aclRolePage.UpdatedAt = DateTime.Now;
                    res.Add(aclRolePage);
                }
            }
            return res.ToArray();
        }
    }
}
