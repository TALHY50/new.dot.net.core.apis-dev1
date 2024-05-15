using ACL.Database;
using SharedLibrary.Services;
using ACL.Response.V1;
using ACL.Utilities;
using ACL.Requests.V1;
using System.Net;
using ACL.Application.Interfaces;
using ACL.Application.Interfaces.Repositories.V1;
using ACL.Core.Models;
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
