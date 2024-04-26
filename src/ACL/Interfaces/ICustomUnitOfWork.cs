using ACL.Services;
using System.Data;
using ACL.Database;
using ACL.Interfaces.Repositories.V1;
using Microsoft.EntityFrameworkCore.Storage;
using ACL.Interfaces.Repositories;
using ACL.Controllers.V1;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Globalization;
using System.Reflection;
using System.Resources;
using ACL.Repositories.V1;
using SharedLibrary.Interfaces;


namespace ACL.Interfaces
{
    public interface ICustomUnitOfWork : IDisposable, IUnitOfWork<ApplicationDbContext>
    {
        ICustomUnitOfWork _unitOfWork { get; }
        IAclCompanyRepository AclCompanyRepository { get; }
        IAclCompanyModuleRepository AclCompanyModuleRepository { get; }
        IAclModuleRepository AclModuleRepository { get; }
        IAclSubModuleRepository AclSubModuleRepository { get; }
        IAclRoleRepository AclRoleRepository { get; }
        IAclUserGroupRoleRepository AclUserGroupRoleRepository { get; }
        IAclRolePageRepository AclRolePageRepository { get; }

        IAclPageRepository AclPageRepository { get; }
        IAclPageRouteRepository AclPageRouteRepository { get; }
        IAclUserRepository AclUserRepository { get; }
        IAclUserUserGroupRepository AclUserUserGroupRepository { get; }
        IAclPasswordRepository AclPasswordRepository { get; }
        IAclUserGroupRepository AclUserGroupRepository { get; }
        IAclStateRepository AclStateRepository { get; }
    }
}