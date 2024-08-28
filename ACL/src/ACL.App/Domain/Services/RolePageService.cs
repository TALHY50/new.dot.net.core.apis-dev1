﻿using ACL.App.Application.Interfaces.Repositories;
using ACL.App.Contracts.Requests;
using ACL.App.Contracts.Responses;
using ACL.App.Domain.Entities;
using ACL.App.Infrastructure.Auth.Auth;
using ACL.App.Infrastructure.Persistence.Context;
using ACL.App.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Contracts.Common;

namespace ACL.App.Domain.Services
{
    public class RolePageService : RolePageRepository, IRolePageService
    {
        /// <inheritdoc/>
        public ScopeResponse ScopeResponse;
        /// <inheritdoc/>
        public MessageResponse MessageResponse;
        private readonly string _modelName = "Role Page";

        /// <inheritdoc/>
        public new ApplicationDbContext Context { get; }

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPageRepository _pageRepository;
        public new static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public RolePageService(ApplicationDbContext dbContext, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository, IPageRepository pageRepository) : base(dbContext, userRepository, httpContextAccessor, roleRepository, pageRepository)
        {
             this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._pageRepository = pageRepository;
            this.ScopeResponse = new ScopeResponse();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Dereference of a possibly null reference.
            this.MessageResponse = new MessageResponse(this._modelName, AppAuth.GetAuthInfo().Language);
            Context = dbContext;
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, Context);
            AppAuth.SetAuthInfo(ContextAccessor);
        }
                /// <inheritdoc/>
        public async Task<ScopeResponse> GetAllById(ulong id)
        {
            List<RolePage>? res = await Context.AclRolePages.Where(x => x.RoleId == id).ToListAsync();
            if (res.Any())
            {
                this.ScopeResponse.Message = this.MessageResponse.fetchMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
            }
            else
            {
                this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Data = res;
            this.ScopeResponse.Timestamp = DateTime.Now;

            return this.ScopeResponse;
        }
        /// <inheritdoc/>
        public async Task<ScopeResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest req)
        {
            try
            {
                List<RolePage>? res = await Context.AclRolePages.Where(x => x.RoleId == req.RoleId).ToListAsync();
                RolePage[]? check = PrepareData(req);
                if (check.Length != 0)
                {
                    DeleteAll(res.ToArray());
                    this.ScopeResponse.Data = AddAll(check);
                    this.ScopeResponse.StatusCode = AppStatusCode.SUCCESS;
                    this.ScopeResponse.Message = this.MessageResponse.editMessage;
                    List<ulong>? userIds = this._userRepository.GetUserIdByChangePermission(null, null, req.RoleId);
                    if (userIds != null)
                    {
                        this._userRepository.UpdateUserPermissionVersion(userIds);
                    }
                }
                else
                {
                    this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
                    this.ScopeResponse.Message = this.MessageResponse.editFail;
                }

            }
            catch (Exception ex)
            {
                this.ScopeResponse.Message = ex.Message;
                this.ScopeResponse.StatusCode = AppStatusCode.FAIL;
            }
            this.ScopeResponse.Timestamp = DateTime.Now;
            return this.ScopeResponse;
        }

        /// <inheritdoc/>
        public RolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest req)
        {
            IList<RolePage> res = new List<RolePage>();
            bool roleExist = this._roleRepository.IsExist(req.RoleId);
            if (roleExist)
            {
                foreach (ulong page in req.PageIds)
                {
                    bool exists = res.Any(r => r.RoleId == page);
                    bool pageExist = this._pageRepository.IsExist(page);
                    if (!pageExist)
                    {
                        throw new Exception("Page Id "+page +"  not valid!");
                    }
                    if (!exists && pageExist && roleExist)
                    {
                        RolePage rolePage = new RolePage();
                        rolePage.Id = 0;
                        rolePage.RoleId = req.RoleId;
                        rolePage.PageId = page;
                        rolePage.CreatedAt = DateTime.Now;
                        rolePage.UpdatedAt = DateTime.Now;
                        res.Add(rolePage);
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