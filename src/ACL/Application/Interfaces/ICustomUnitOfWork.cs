using ACL.Application.Interfaces.Repositories.V1;
using ACL.Application.Interfaces.ServiceInterfaces;
using ACL.Application.Ports.Repositories;
using ACL.Application.Ports.Services;
using ACL.Database;
using ACL.Services;
using SharedLibrary.Interfaces;

namespace ACL.Application.Interfaces
{
    public interface ICustomUnitOfWork : IDisposable, IUnitOfWork<ApplicationDbContext, CustomUnitOfWork>
    {
        ICustomUnitOfWork _unitOfWork { get; }
        IUnitOfWork<ApplicationDbContext,CustomUnitOfWork> _baseUnitOfWork { get; }
        ICryptographyService cryptographyService { get; }
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