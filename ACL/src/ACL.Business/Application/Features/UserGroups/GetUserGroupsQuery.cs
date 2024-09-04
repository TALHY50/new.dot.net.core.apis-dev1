using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace ACL.Business.Application.Features.UserGroups
{
    //[Authorize]
    public record GetUserGroupsQuery() : IRequest<ErrorOr<List<Usergroup>>>;

    public class GetUserGroupsQueryValidator : AbstractValidator<GetUserGroupsQuery>
    {
        public GetUserGroupsQueryValidator()
        {

        }
    }

    public class GetUserGroupsQueryHandler
        : UserGroupBase, IRequestHandler<GetUserGroupsQuery, ErrorOr<List<Usergroup>>>
    {
        private readonly IUserGroupRepository _repository;

        public GetUserGroupsQueryHandler(IUserGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Usergroup>>> Handle(GetUserGroupsQuery request, CancellationToken cancellationToken)
        {
            List<Usergroup>? userGroups;

            userGroups = _repository.All();

            return userGroups;
        }
    }
}
