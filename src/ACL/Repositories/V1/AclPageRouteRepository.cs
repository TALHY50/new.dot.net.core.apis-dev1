using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces.Repositories.V1;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace ACL.Repositories.V1
{
    public class AclPageRouteRepository : GenericRepository<AclPageRoute, ApplicationDbContext>, IAclPageRouteRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Page Route";

        public AclPageRouteRepository(IUnitOfWork<ApplicationDbContext> _unitOfWork) : base(_unitOfWork)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork);
        }
    }
}
