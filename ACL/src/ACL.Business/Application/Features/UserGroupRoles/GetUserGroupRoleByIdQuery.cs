using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.UserGroupRoles
{
    public record GetUserGroupRoleByUserGroupIdQuery(uint user_group_id) : IRequest<ErrorOr<List<UsergroupRole?>>>;


    public class GetUserGroupRoleByRoleIdQueryValidator : AbstractValidator<GetUserGroupRoleByUserGroupIdQuery>
    {
        public GetUserGroupRoleByRoleIdQueryValidator()
        {
            RuleFor(x => x.user_group_id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class GetUserGroupRoleByUserGroupIdQueryHandler : UserGroupRoleBase, IRequestHandler<GetUserGroupRoleByUserGroupIdQuery, ErrorOr<List<UsergroupRole?>>>
    {
        private readonly IUserGroupRoleRepository _repository;        

        public GetUserGroupRoleByUserGroupIdQueryHandler(IUserGroupRoleRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<ErrorOr<List<UsergroupRole?>>> Handle(GetUserGroupRoleByUserGroupIdQuery request, CancellationToken cancellationToken)
        {
            var usergroupRole = _repository.FindByUserGroupId(request.user_group_id);
            if (usergroupRole.Count() == 0)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return usergroupRole!;
        }
    }
}
