using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;
using static ACL.Route.AclRoutesUrl;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclRolePageRepository : GenericRepository<AclRolePage>, IAclRolePageRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Role Page";
        public AclRolePageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);

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
            using (var transaction = base.BeginTransaction())
            {
                try
                {
                    var removedEntities = await base.RemoveRange(res);
                    await base.AddRange(check);
                    await base.CommitTransactionAsync();
                }
                catch (Exception ex)
                {
                    await base.RollbackTransactionAsync();
                    this.aclResponse.Message = ex.Message;
                    this.aclResponse.StatusCode = AppStatusCode.FAIL;
                }
            }
            await base.CompleteAsync();
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
