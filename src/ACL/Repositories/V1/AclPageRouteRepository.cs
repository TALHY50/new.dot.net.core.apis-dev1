using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Response.V1;
using ACL.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace ACL.Repositories.V1
{
    public class AclPageRouteRepository : GenericRepository<AclPageRoute, ApplicationDbContext,ICustomUnitOfWork>, IAclPageRouteRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Page Route";

        public AclPageRouteRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork);
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
        }
    }
}
