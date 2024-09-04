using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.RolePages;

public record GetRolePageByRoleIdQuery(uint role_id) : IRequest<ErrorOr<List<RolePage?>>>;


public class GetRolePageByRoleIdQueryValidator : AbstractValidator<GetRolePageByRoleIdQuery>
{
    public GetRolePageByRoleIdQueryValidator()
    {
        RuleFor(x => x.role_id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
    }
}

public class GetRolePageByRoleIdQueryHandler : RolePageBase, IRequestHandler<GetRolePageByRoleIdQuery, ErrorOr<List<RolePage?>>>
{
    private readonly IRolePageRepository _repository;

    public GetRolePageByRoleIdQueryHandler(IRolePageRepository repository)
    {
        _repository = repository;
    }
    public async Task<ErrorOr<List<RolePage?>>> Handle(GetRolePageByRoleIdQuery request, CancellationToken cancellationToken)
    {
        // Get role page by role id
        return _repository.FindByRoleId(request.role_id);
    }
}

