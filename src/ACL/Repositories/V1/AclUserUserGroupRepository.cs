using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Response.V1;
using ACL.Services;
using ACL.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace ACL.Repositories.V1
{
    public class AclUserUserGroupRepository : GenericRepository<AclUserUsergroup, ApplicationDbContext, ICustomUnitOfWork>, IAclUserUserGroupRepository
    {
        public AclResponse aclResponse;
        public MessageResponse messageResponse;
        private string modelName = "User User Group";
        public AclUserUserGroupRepository(ICustomUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ApplicationDbContext)
        {
            AppAuth.SetAuthInfo();
            aclResponse = new AclResponse();
            messageResponse = new MessageResponse(modelName, _unitOfWork, AppAuth.GetAuthInfo().Language);
        }
    }
}
