using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Utilities;
using ACL.UseCases.Interfaces.Repositories.V1;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;
using static ACL.Route.AclRoutesUrl;

namespace ACL.Infrastructure.Repositories.V1
{
    /// <inheritdoc/>
    public class AclRolePageRepository : IAclRolePageRepository
    {
        /// <inheritdoc/>
        public AclResponse aclResponse;
        /// <inheritdoc/>
        public MessageResponse messageResponse;
        private string modelName = "Role Page";
        /// <inheritdoc/>
        public readonly ApplicationDbContext _dbContext;
        /// <inheritdoc/>
        public AclRolePageRepository(ApplicationDbContext dbContext)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
            _dbContext = dbContext;
        }
        /// <inheritdoc/>
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
        /// <inheritdoc/>
        public async Task<AclResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest req)
        {
            try
            {
                List<AclRolePage>? res = await _dbContext.AclRolePages.Where(x => x.RoleId == req.RoleId).ToListAsync();
                AclRolePage[]? check = PrepareData(req);
                DeleteAll(res.ToArray());
                this.aclResponse.Data = AddAll(check);
                this.aclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            catch (Exception ex)
            {
                this.aclResponse.Message = ex.Message;
                this.aclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.aclResponse.Timestamp = DateTime.Now;
            return this.aclResponse;
        }

        /// <inheritdoc/>
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
        /// <inheritdoc/>
        public List<AclRolePage>? All()
        {
            try
            {
                return _dbContext.AclRolePages.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclRolePage? Find(ulong id)
        {
            try
            {
                return _dbContext.AclRolePages.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclRolePage? Add(AclRolePage aclRolePage)
        {
            try
            {
                _dbContext.AclRolePages.Add(aclRolePage);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclRolePage).ReloadAsync();
                return aclRolePage;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclRolePage? Update(AclRolePage aclRolePage)
        {
            try
            {
                _dbContext.AclRolePages.Update(aclRolePage);
                _dbContext.SaveChanges();
                _dbContext.Entry(aclRolePage).ReloadAsync();
                return aclRolePage;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclRolePage? Delete(AclRolePage aclRolePage)
        {
            try
            {
                _dbContext.AclRolePages.Remove(aclRolePage);
                _dbContext.SaveChangesAsync();
                return aclRolePage;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclPageRoute? Delete(ulong id)
        {
            try
            {
                var delete = _dbContext.AclPageRoutes.Find(id);
                _dbContext.AclPageRoutes.Remove(delete);
                _dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <inheritdoc/>
        public AclRolePage[]? AddAll(AclRolePage[] aclRolePages)
        {
            try
            {
                _dbContext.AclRolePages.AddRange(aclRolePages);
                _dbContext.SaveChanges();
                return aclRolePages;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclRolePage[]? DeleteAll(AclRolePage[] aclRolePages)
        {
            try
            {
                _dbContext.AclRolePages.RemoveRange(aclRolePages);
                _dbContext.SaveChanges();
                return aclRolePages;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <inheritdoc/>
        public AclRolePage[]? DeleteAllByRoleId(ulong roleId)
        {
            try
            {
                var rolePagesToDelete = _dbContext.AclRolePages.Where(rp => rp.RoleId == roleId);
                _dbContext.AclRolePages.RemoveRange(rolePagesToDelete);
                _dbContext.SaveChanges();
                return rolePagesToDelete.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
