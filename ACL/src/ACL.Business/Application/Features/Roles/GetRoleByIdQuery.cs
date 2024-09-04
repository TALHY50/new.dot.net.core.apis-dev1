using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.Roles
{
    public record GetRoleByIdQuery(uint id) : IRequest<ErrorOr<Role>>;

    public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
    {
        public GetRoleByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Role ID is required");
        }
    }

    public class GetRoleByIdQueryHandler
        : RoleBase, IRequestHandler<GetRoleByIdQuery, ErrorOr<Role>>
    {
        private readonly IRoleRepository _repository;

        public GetRoleByIdQueryHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Role>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (role == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return role;
        }
    }
}
