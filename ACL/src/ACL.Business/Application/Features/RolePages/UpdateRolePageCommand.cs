using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.RolePages;

public record UpdateRolePageCommand(
    uint role_id,
    int[] page_ids
    ) : IRequest<ErrorOr<bool>>;


public class UpdateRolePageCommandValidator : AbstractValidator<UpdateRolePageCommand>
{
    public UpdateRolePageCommandValidator()
    {
        RuleFor(x => x.role_id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        RuleFor(x => x.page_ids).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
    }
}

public class UpdateRolePageCommandHandler : RolePageBase, IRequestHandler<UpdateRolePageCommand, ErrorOr<bool>>
{
    private readonly IRolePageRepository _repository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPageRepository _pageRepository;
    private readonly IUserRepository _userRepository;
    private readonly IGuardAgainstNullUpdate _guard;

    public UpdateRolePageCommandHandler(IRolePageRepository repository, IRoleRepository roleRepository, IPageRepository pageRepository, IUserRepository userRepository, IGuardAgainstNullUpdate guard)
    {
        _repository = repository;
        _roleRepository = roleRepository;
        _pageRepository = pageRepository;
        _userRepository = userRepository;
        _guard = guard;
    }

    public async Task<ErrorOr<bool>> Handle(UpdateRolePageCommand command, CancellationToken cancellationToken)
    {
        // Get role page by role id
        List<RolePage>? rolePages = _repository.FindByRoleId(command.role_id);
        // Prepare role page data
        RolePage[]? rolePagePrepareData = PrepareData(command);
        if (rolePagePrepareData.Length > 0)
        {
            // Delete Previous role page if exit
            if (rolePages is not null)
            {
                _repository.DeleteAll(rolePages.ToArray());
            }
            // insert prepare data
            _repository.AddAll(rolePagePrepareData);
            List<uint>? userIds = _userRepository.GetUserIdByChangePermission(null, null, command.role_id);
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

    public RolePage[] PrepareData(UpdateRolePageCommand req)
    {
        IList<RolePage> res = new List<RolePage>();
        bool roleExist = _roleRepository.IsExist(req.role_id);
        if (roleExist)
        {
            foreach (uint page_id in req.page_ids)
            {
                bool exists = res.Any(r => r.RoleId == page_id);
                bool pageExist = _pageRepository.IsExist(page_id);
                if (!pageExist)
                {
                    continue;
                }
                if (!exists && pageExist && roleExist)
                {
                    RolePage rolePage = new RolePage();
                    rolePage.Id = 0;
                    rolePage.RoleId = req.role_id;
                    rolePage.PageId = page_id;
                    rolePage.CreatedAt = DateTime.Now;
                    rolePage.UpdatedAt = DateTime.Now;
                    res.Add(rolePage);
                }
            }
        }
        return res.ToArray();
    }

}

