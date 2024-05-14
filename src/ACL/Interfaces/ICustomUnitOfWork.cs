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
using ACL.Application.Ports.Repositories;
using ACL.Repositories.V1;
using SharedLibrary.Interfaces;
using ACL.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.Caching.Distributed;


namespace ACL.Interfaces
{
    public interface ICustomUnitOfWork : IDisposable, IUnitOfWork<ApplicationDbContext, CustomUnitOfWork>
    {
        ICustomUnitOfWork _unitOfWork { get; }
        IUnitOfWork<ApplicationDbContext,CustomUnitOfWork> _baseUnitOfWork { get; }
        IAclCompanyRepository AclCompanyRepository { get; }
        IAclCountryRepository AclCountryRepository { get; }
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
        IAclBranchRepository AclBranchRepository { get; }
        IAclBranchService AclBranchService { get; }
    }
}