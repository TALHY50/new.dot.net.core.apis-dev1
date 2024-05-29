using ACL.Application.Ports.Repositories.Auth;
using ACL.Application.Ports.Repositories.Module;
using ACL.Application.Ports.Repositories.Role;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Core.Entities.Module;
using ACL.Core.Entities.Role;
using ACL.Infrastructure.Persistence.Configurations;
using ACL.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Response.CustomStatusCode;
using static ACL.Infrastructure.Route.AclRoutesUrl;

namespace ACL.Infrastructure.Persistence.Repositories.Role
{
    /// <inheritdoc/>
    public class AclRolePageRepository : IAclRolePageRepository
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Role Page";

        /// <inheritdoc/>
        public ApplicationDbContext Context { get; }

        private readonly IAclUserRepository _aclUserRepository;
        private readonly IAclRoleRepository _aclRoleRepository;
        private readonly IAclPageRepository _aclPageRepository;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclRolePageRepository(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor, IAclRoleRepository aclRoleRepository, IAclPageRepository aclPageRepository)
        {
            _aclUserRepository = aclUserRepository;
            _aclRoleRepository = aclRoleRepository;
            _aclPageRepository = aclPageRepository;
            this.AclResponse = new AclResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Dereference of a possibly null reference.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            Context = dbContext;
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, Context);
            AppAuth.SetAuthInfo(ContextAccessor);
        }
        /// <inheritdoc/>
        public async Task<AclResponse> GetAllById(ulong id)
        {
            List<AclRolePage>? res = await Context.AclRolePages.Where(x => x.RoleId == id).ToListAsync();
            if (res.Any())
            {
                this.AclResponse.Message = this.MessageResponse.fetchMessage;
                this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.AclResponse.Message = this.MessageResponse.notFoundMessage;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Data = res;
            this.AclResponse.Timestamp = DateTime.Now;

            return this.AclResponse;
        }
        /// <inheritdoc/>
        public async Task<AclResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest req)
        {
            try
            {
                List<AclRolePage>? res = await Context.AclRolePages.Where(x => x.RoleId == req.RoleId).ToListAsync();
                AclRolePage[]? check = PrepareData(req);
                if (check.Length != 0)
                {
                    DeleteAll(res.ToArray());
                    this.AclResponse.Data = AddAll(check);
                    this.AclResponse.StatusCode = AppStatusCode.SUCCESS;
                    this.AclResponse.Message = this.MessageResponse.editMessage;
                    List<ulong>? userIds = _aclUserRepository.GetUserIdByChangePermission(null, null, req.RoleId);
                    if (userIds != null)
                    {
                        _aclUserRepository.UpdateUserPermissionVersion(userIds);
                    }
                }
                else
                {
                    this.AclResponse.StatusCode = AppStatusCode.FAIL;
                    this.AclResponse.Message = this.MessageResponse.editFail;
                }

            }
            catch (Exception ex)
            {
                this.AclResponse.Message = ex.Message;
                this.AclResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.AclResponse.Timestamp = DateTime.Now;
            return this.AclResponse;
        }

        /// <inheritdoc/>
        public AclRolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest req)
        {
            IList<AclRolePage> res = new List<AclRolePage>();
            bool roleExist = _aclRoleRepository.IsExist(req.RoleId);
            if (roleExist)
            {
                foreach (ulong page in req.PageIds)
                {
                    bool exists = res.Any(r => r.RoleId == page);
                    bool pageExist = _aclPageRepository.IsExist(page);
                    if (!pageExist)
                    {
                        throw new Exception("Page Id "+page +"  not valid!");
                    }
                    if (!exists && pageExist && roleExist)
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
            }
            else
            {
                throw new Exception("Role Id not valid!");
            }
            return res.ToArray();
        }
        /// <inheritdoc/>
        public List<AclRolePage>? All()
        {
            try
            {
                return Context.AclRolePages.ToList();
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
                return Context.AclRolePages.Find(id);
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
                Context.AclRolePages.Add(aclRolePage);
                Context.SaveChanges();
                Context.Entry(aclRolePage).ReloadAsync();
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
                Context.AclRolePages.Update(aclRolePage);
                Context.SaveChanges();
                Context.Entry(aclRolePage).ReloadAsync();
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
                Context.AclRolePages.Remove(aclRolePage);
                Context.SaveChangesAsync();
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
                var delete = Context.AclPageRoutes.Find(id);
                Context.AclPageRoutes.Remove(delete);
                Context.SaveChangesAsync();
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
                Context.AclRolePages.AddRange(aclRolePages);
                Context.SaveChanges();
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
                Context.AclRolePages.RemoveRange(aclRolePages);
                Context.SaveChanges();
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
                var rolePagesToDelete = Context.AclRolePages.Where(rp => rp.RoleId == roleId);
                Context.AclRolePages.RemoveRange(rolePagesToDelete);
                Context.SaveChanges();
                return rolePagesToDelete.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
