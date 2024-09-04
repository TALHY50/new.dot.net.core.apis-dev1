using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.UserGroups
{
    //[Authorize]
    public record UpdateUserGroupByIdCommand(
        uint id, 
        string group_name,
        sbyte category,
        sbyte status) : IRequest<ErrorOr<Usergroup>>;

    public class UpdateUserGroupByIdCommandValidator : AbstractValidator<UpdateUserGroupByIdCommand>
    {
        public UpdateUserGroupByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("UserGroup Id is required");
            RuleFor(x => x.group_name).NotEmpty().WithMessage("GroupName Id is required");
            RuleFor(x => x.category).NotEmpty().WithMessage("Category Id is required");
            RuleFor(x => x.status).NotEmpty().WithMessage("Status Id is required");
        }
    }

    public class UpdateUserGroupByIdCommandHandler : UserGroupBase, IRequestHandler<UpdateUserGroupByIdCommand, ErrorOr<Usergroup>>
    {
        private readonly IUserGroupRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateUserGroupByIdCommandHandler(IUserGroupRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<Usergroup>> Handle(UpdateUserGroupByIdCommand command, CancellationToken cancellationToken)
        {
            Usergroup? userGroup = _repository.Find(command.id);
            if (userGroup == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            userGroup = PrepareInputData(command, userGroup);

            userGroup.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(userGroup, cancellationToken);

            return userGroup;
        }


        private Usergroup PrepareInputData(UpdateUserGroupByIdCommand request, Usergroup? existingGroup)
        {

            existingGroup.GroupName = request.group_name;
            existingGroup.Category = request.category;
            existingGroup.Status = request.status;


            existingGroup.CompanyId = (existingGroup.CompanyId == 0) ? AppAuth.GetAuthInfo().CompanyId : existingGroup.CompanyId;

            existingGroup.UpdatedAt = DateTime.Now;

            return existingGroup;
        }
    }
}
