using ACL.Database.Models;
using ACL.Database;
using ACL.Interfaces.Repositories.V1;
using ACL.Interfaces;
using SharedLibrary.Services;
using ACL.Response.V1;
using ACL.Utilities;
using ACL.Requests.V1;
using System.Net;
using Castle.Components.DictionaryAdapter.Xml;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Repositories.V1
{
    public class AclBranchRepository : GenericRepository<AclBranch, ApplicationDbContext, ICustomUnitOfWork>, IAclBranchRepository
    {
        public AclBranchRepository(ICustomUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.ApplicationDbContext)
        {
        }
    }
}
