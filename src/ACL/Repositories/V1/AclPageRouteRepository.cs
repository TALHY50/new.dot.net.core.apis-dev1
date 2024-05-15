using ACL.Core.Models;
using ACL.Database;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Response.V1;
using ACL.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Repositories.V1
{
    public class AclPageRouteRepository : GenericRepository<AclPageRoute, ApplicationDbContext, ICustomUnitOfWork>, IAclPageRouteRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "Page Route";

        public AclPageRouteRepository(ICustomUnitOfWork _unitOfWork) : base(_unitOfWork, _unitOfWork.ApplicationDbContext)
        {
            aclResponse = new AclResponse();
            AppAuth.SetAuthInfo(); // sent object to this class when auth is found
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }
    }
}
