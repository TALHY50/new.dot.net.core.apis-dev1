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
    public class AclPageRouteRepository : GenericRepository<AclPageRoute>, IAclPageRouteRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Page Route";

        public AclPageRouteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            this.messageResponse = new MessageResponse(this.modelName, AppAuth.GetAuthInfo().Language);
        }
    }
}
