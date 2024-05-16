using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclUserUserGroupRepository : IAclUserUserGroupRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User User Group";
        ApplicationDbContext _dbContext;
        public AclUserUserGroupRepository(ApplicationDbContext dbContext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }

        public AclUserUsergroup Add(AclUserUsergroup request)
        {
            _dbContext.Add(request);
            _dbContext.SaveChanges();
            _dbContext.Entry(request).Reload();
            return request;
        }
        /// <inheritdoc/>

        public AclUserUsergroup DeleteById(ulong id)
        {
            AclUserUsergroup? request = _dbContext.AclUserUsergroups.Find(id);
            _dbContext.AclUserUsergroups.Remove(request);
            _dbContext.SaveChanges();
            return request;
        }
        /// <inheritdoc/>
        public AclUserUsergroup Edit(ulong id, AclUserUsergroup? request)
        {
            AclUserUsergroup? requestOne = _dbContext.AclUserUsergroups.Find(id);
            if (request == null)
            {
                request = requestOne;
            }
            _dbContext.AclUserUsergroups.Update(request);
            _dbContext.SaveChanges();
            _dbContext.Entry(request).Reload();
            return request;
        }
        /// <inheritdoc/>
        public AclUserUsergroup FindById(ulong id)
        {
            return _dbContext.AclUserUsergroups.Find(id);
        }
        /// <inheritdoc/>
        public List<AclUserUsergroup> GetAll()
        {
            return _dbContext.AclUserUsergroups.ToList();
        }
    }
}
