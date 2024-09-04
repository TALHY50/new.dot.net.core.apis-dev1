
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace ACL.Business.Application.Features.Roles
{
    public record GetRolesQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Role>>>;

    public class GetRolesQueryValidator : AbstractValidator<GetRolesQuery>
    {
        public GetRolesQueryValidator()
        {
            
        }
    }

    public class GetRolesQueryHandler
        : RoleBase, IRequestHandler<GetRolesQuery, ErrorOr<List<Role>>>
    {
        private readonly IRoleRepository _repository;

        public GetRolesQueryHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Role>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            List<Role>? roles;

            roles = _repository.All();

            return roles;
        }
    }
}
