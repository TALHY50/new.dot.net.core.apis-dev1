using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.UserGroups
{
    //[Authorize]
    public record GetUserGroupByIdQuery(uint id) : IRequest<ErrorOr<Usergroup>>;

    public class GetUserGroupByIdQueryValidator : AbstractValidator<GetUserGroupByIdQuery>
    {
        public GetUserGroupByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("UserGroup ID is required");
        }
    }

    public class GetUserGroupByIdQueryHandler
        : UserGroupBase, IRequestHandler<GetUserGroupByIdQuery, ErrorOr<Usergroup>>
    {
        private readonly IUserGroupRepository _repository;

        public GetUserGroupByIdQueryHandler(IUserGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Usergroup>> Handle(GetUserGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var userGroup = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (userGroup == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return userGroup;
        }
    }
}
