using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using Org.BouncyCastle.Ocsp;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.UserGroupRoles
{
    public record UpdateUserGroupRoleCommand(
    uint user_group_id,
    uint[] role_ids
    ) : IRequest<ErrorOr<bool>>;


    public class UpdateUserGroupRoleCommandValidator : AbstractValidator<UpdateUserGroupRoleCommand>
    {
        public UpdateUserGroupRoleCommandValidator()
        {
            RuleFor(x => x.user_group_id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            RuleFor(x => x.role_ids).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class UpdateUserGroupRoleCommandHandler : UserGroupRoleBase, IRequestHandler<UpdateUserGroupRoleCommand, ErrorOr<bool>>
    {
        private readonly IUserGroupRoleRepository _userGroupRoleRepository;
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGuardAgainstNullUpdate _guard;
        private readonly ApplicationDbContext _dbContext;


        public UpdateUserGroupRoleCommandHandler(IUserGroupRoleRepository userGroupRoleRepository, IUserGroupRepository userGroupRepository, IRoleRepository roleRepository, IUserRepository userRepository, IGuardAgainstNullUpdate guard, ApplicationDbContext dbContext)
        {
            _userGroupRoleRepository = userGroupRoleRepository;
            _userGroupRepository = userGroupRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _guard = guard;
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<bool>> Handle(UpdateUserGroupRoleCommand command, CancellationToken cancellationToken)
        {

            var userGroupRoles = GetUserGroupRoles(command);
            var aclUserGroupRole = _userGroupRoleRepository.FindByUserGroupId(command.user_group_id).ToList();

            if (userGroupRoles.Count() > 0)
            {
                if (aclUserGroupRole.Count() > 0)
                {
                    _userGroupRoleRepository.DeleteAll(aclUserGroupRole.ToArray());
                }
                _userGroupRoleRepository.AddAll(userGroupRoles);
                _userGroupRoleRepository.ReloadEntities(userGroupRoles);
                List<uint>? userIds = _userRepository.GetUserIdByChangePermission(null, null, null, null, command.user_group_id);
                if (userIds != null)
                {
                    _userRepository.UpdateUserPermissionVersion(userIds);
                }
            }
            else
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return true;
        }

        public UsergroupRole[] GetUserGroupRoles(UpdateUserGroupRoleCommand request)
        {

            //var userGroupRoles = request.role_ids.Select(roleId => new UsergroupRole
            //{
            //    UsergroupId = _userGroupRoleRepository.UserGroupIdExist(request.user_group_id),
            //    RoleId = _userGroupRoleRepository.RoleIdExist(roleId),
            //    CompanyId = 1,//AppAuth.GetAuthInfo().CompanyId,
            //    CreatedAt = DateTime.Now,
            //    UpdatedAt = DateTime.Now,
            //}).ToArray();

            IList<UsergroupRole> res = new List<UsergroupRole>();
            bool userGroupExist = _userGroupRepository.IsExist(request.user_group_id);
            if (userGroupExist)
            {
                foreach (uint role_id in request.role_ids)
                {
                    bool exists = res.Any(r => r.RoleId == role_id);
                    bool roleExist = _roleRepository.IsExist(role_id);
                    if (!roleExist)
                    {
                        continue;
                    }
                    if (!exists && roleExist && userGroupExist)
                    {
                        UsergroupRole usergroupRole = new UsergroupRole();
                        //usergroupRole.Id = 0;
                        usergroupRole.UsergroupId = request.user_group_id;
                        usergroupRole.RoleId = role_id;
                        usergroupRole.CreatedAt = DateTime.Now;
                        usergroupRole.UpdatedAt = DateTime.Now;
                        res.Add(usergroupRole);
                    }
                }
            }
            return res.ToArray();
        }
    }
}