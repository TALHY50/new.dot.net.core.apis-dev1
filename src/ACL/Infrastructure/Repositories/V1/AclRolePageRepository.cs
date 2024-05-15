using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using ACL.Requests;
using ACL.Response.V1;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;
using static ACL.Route.AclRoutesUrl;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclRolePageRepository : GenericRepository<AclRolePage, ApplicationDbContext, ICustomUnitOfWork>, IAclRolePageRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Role Page";
        public AclRolePageRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);

        }

        public async Task<AclResponse> GetAllById(ulong id)
        {
            var res = await base.Where(x => x.RoleId == id).ToListAsync();
            if (res.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Data = res;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }

        public async Task<AclResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest req)
        {
            var res = await base.Where(x => x.RoleId == req.RoleId).ToListAsync();
            var check = PrepareData(req);
            using (var transaction = this._unitOfWork.BeginTransaction())
            {
                try
                {
                    var removedEntities = await base.RemoveRange(res);
                    await base.AddRange(check);
                    await this._unitOfWork.CommitTransactionAsync();
                }
                catch (Exception ex)
                {
                    await this._unitOfWork.RollbackTransactionAsync();
                    this.aclResponse.Message = ex.Message;
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                }
            }
            await this._unitOfWork.CompleteAsync();
            await ReloadEntitiesAsync(check);
            res = check.ToList();
            if (res.Any())
            {
                this.aclResponse.Message = this.messageResponse.fetchMessage;
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.aclResponse.Message = this.messageResponse.notFoundMessage;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }

            this.aclResponse.Data = res;
            this.aclResponse.Timestamp = DateTime.Now;

            return this.aclResponse;
        }


        public AclRolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest req)
        {
            IList<AclRolePage> res = new List<AclRolePage>();
            foreach (ulong page in req.PageIds)
            {
                bool exists = res.Any(r => r.RoleId == page);
                if (!exists)
                {
                    AclRolePage aclRolePage = new AclRolePage();
                    aclRolePage.Id = 0;
                    aclRolePage.RoleId = req.RoleId;
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
