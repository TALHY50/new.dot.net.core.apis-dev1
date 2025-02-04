﻿using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class PageRepository :EfRepository<Page>, IPageRepository
    {
        private readonly IPageRouteRepository _routeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public PageRepository(ApplicationDbContext dbContext, IPageRouteRepository routeRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor):base(dbContext)
        {
            this._dbContext = dbContext;
            this._routeRepository = routeRepository;
            this._userRepository = userRepository;
            ContextAccessor = httpContextAccessor;
            //AppAuth.Initialize(ContextAccessor, this._dbContext);
            //AppAuth.SetAuthInfo(ContextAccessor);
        }

        /// <inheritdoc/>
        public void DeletePageRouteByPageId(uint pageId)
        {
            this._routeRepository.DeleteAllByPageId(pageId);
        }
        /// <inheritdoc/>
        public List<Page>? All()
        {
            try
            {
                return this._dbContext.AclPages.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Page? Find(uint id)
        {
            try
            {
                return this._dbContext.AclPages.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Page? Add(Page page)
        {
            try
            {
                this._dbContext.AclPages.Add(page);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(page).ReloadAsync();
                return page;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Page? Update(Page page)
        {
            try
            {
                this._dbContext.AclPages.Update(page);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(page).ReloadAsync();
                return page;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Page? Delete(Page page)
        {
            try
            {
                this._dbContext.AclPages.Remove(page);
                this._dbContext.SaveChangesAsync();
                return page;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Page? Delete(uint id)
        {
            try
            {
                var delete = this._dbContext.AclPages.Find(id);
                if (delete != null)
                    this._dbContext.AclPages.Remove(delete);
                this._dbContext.SaveChangesAsync();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public bool IsAclPageIdExist(uint id)
        {
            return this._dbContext.AclPages.Any(x => x.Id == id);
        }

        public bool IsModuleIdExist(uint id)
        {
            return this._dbContext.AclModules.Any(x => x.Id == id);
        }

        public bool IsSubModuleIdExist(uint id)
        {
            return this._dbContext.AclSubModules.Any(x => x.Id == id);
        }
        public bool IsExist(uint id)
        {
            return this._dbContext.AclPages.Any(i => i.Id == id);
        }
    }
}
