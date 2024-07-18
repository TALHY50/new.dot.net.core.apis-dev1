using App.Contracts.Requests;
using App.Contracts.Response;
using App.Domain.Ports.Repositories.Auth;
using App.Domain.Ports.Repositories.Module;
using App.Domain.Ports.Repositories.Role;
using App.Domain.Ports.Services.Role;
using App.Domain.Role;
using App.Infrastructure.Persistence.Configurations;
using App.Infrastructure.Persistence.Repositories.Role;
using App.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Contracts.Response;

namespace App.Infrastructure.Services.Role
{
    public class AclRolePageService : AclRolePageRepository, IAclRolePageService
    {
        /// <inheritdoc/>
        public AclResponse AclResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Role Page";

        /// <inheritdoc/>
        public new ApplicationDbContext Context { get; }

        private readonly IAclUserRepository _aclUserRepository;
        private readonly IAclRoleRepository _aclRoleRepository;
        private readonly IAclPageRepository _aclPageRepository;
        public new static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public AclRolePageService(ApplicationDbContext dbContext, IAclUserRepository aclUserRepository, IHttpContextAccessor httpContextAccessor, IAclRoleRepository aclRoleRepository, IAclPageRepository aclPageRepository) : base(dbContext, aclUserRepository, httpContextAccessor, aclRoleRepository, aclPageRepository)
        {
             this._aclUserRepository = aclUserRepository;
            this._aclRoleRepository = aclRoleRepository;
            this._aclPageRepository = aclPageRepository;
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
                    List<ulong>? userIds = this._aclUserRepository.GetUserIdByChangePermission(null, null, req.RoleId);
                    if (userIds != null)
                    {
                        this._aclUserRepository.UpdateUserPermissionVersion(userIds);
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
            bool roleExist = this._aclRoleRepository.IsExist(req.RoleId);
            if (roleExist)
            {
                foreach (ulong page in req.PageIds)
                {
                    bool exists = res.Any(r => r.RoleId == page);
                    bool pageExist = this._aclPageRepository.IsExist(page);
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
    }
}
