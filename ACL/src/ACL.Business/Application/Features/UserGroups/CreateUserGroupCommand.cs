using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ErrorOr;
using FluentValidation;
using MediatR;


namespace ACL.Business.Application.Features.UserGroups
{
    //[Authorize]
    public record CreateUserGroupCommand(
        string group_name,
        sbyte category,
        sbyte status) : IRequest<ErrorOr<Usergroup>>;

    public class CreateUserGroupCommandValidator : AbstractValidator<CreateUserGroupCommand>
    {
        public CreateUserGroupCommandValidator()
        {
            RuleFor(x => x.group_name).NotEmpty().WithMessage("GroupName Id is required");
            RuleFor(x => x.category).NotEmpty().WithMessage("Category Id is required");
            RuleFor(x => x.status).NotEmpty().WithMessage("Status Id is required");
        }
    }

    public class CreateUserGroupCommandHandler : UserGroupBase, IRequestHandler<CreateUserGroupCommand, ErrorOr<Usergroup>>
    {
        private readonly IUserGroupRepository _userGroupRepository;
        private readonly ICompanyRepository _companyRepository;
        // Constructor
        public CreateUserGroupCommandHandler(
            IUserGroupRepository usergroupRepository,
            ICompanyRepository companyRepository)
        {
            _userGroupRepository = usergroupRepository ?? throw new ArgumentNullException(nameof(usergroupRepository));
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(_companyRepository));
        }
        public async Task<ErrorOr<Usergroup>> Handle(CreateUserGroupCommand command, CancellationToken cancellationToken)
        {
            Usergroup? userGroup = PrepareInputData(command);

            var result = await _userGroupRepository.AddAsync(userGroup);

            return result;
        }

        private Usergroup PrepareInputData(CreateUserGroupCommand request, Usergroup? existingGroup = null)
        {
            if(existingGroup == null)
            {
                existingGroup = new Usergroup();
                existingGroup.CreatedAt = DateTime.UtcNow;
            }

            existingGroup.GroupName = request.group_name;
            existingGroup.Category = request.category;
            existingGroup.Status = request.status;


            existingGroup.CompanyId = (existingGroup.CompanyId == 0) ? AppAuth.GetAuthInfo().CompanyId : existingGroup.CompanyId;

            existingGroup.UpdatedAt = DateTime.Now;

            return existingGroup;
        }
    }
}
