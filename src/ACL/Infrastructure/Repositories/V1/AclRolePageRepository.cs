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
    public class AclRolePageRepository : IAclRolePageRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Role Page";

        public readonly ApplicationDbContext _dbContext;

        public AclRolePageRepository(ApplicationDbContext dbContext)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
        }

        public async Task<AclResponse> GetAllById(ulong id)
        {
            List<AclRolePage>? res = await _dbContext.AclRolePages.Where(x => x.RoleId == id).ToListAsync();
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
            List<AclRolePage>? res = await _dbContext.AclRolePages.Where(x => x.RoleId == req.RoleId).ToListAsync();
            AclRolePage[]? check = PrepareData(req);

            try
            {
                _dbContext.AclRolePages.RemoveRange(res);
                _dbContext.AclRolePages.AddRange(check);
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            await _dbContext.SaveChangesAsync();
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
