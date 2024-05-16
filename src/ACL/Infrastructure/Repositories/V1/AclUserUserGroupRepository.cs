using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Contracts.Response;
using ACL.Contracts.Response.V1;
using ACL.Core.Models;
using ACL.Infrastructure.Database;
using ACL.Infrastructure.Repositories.GenericRepository;
using ACL.Infrastructure.Utilities;
using SharedLibrary.Services;

namespace ACL.Infrastructure.Repositories.V1
{
    public class AclUserUserGroupRepository : GenericRepository<AclUserUsergroup>, IAclUserUserGroupRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User User Group";
        public AclUserUserGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            AppAuth.SetAuthInfo();
            this.aclResponse = new AclResponse();
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }
    }
}
