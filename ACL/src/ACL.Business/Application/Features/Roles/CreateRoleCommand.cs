using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Business.Application.Features.Roles
{
    public record CreateRoleCommand(
        string? name,
        string? title,
        sbyte status) : IRequest<ErrorOr<Role>>;
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.status).NotEmpty();
        }
    }
    public class CreateRoleCommandHandler
        : RoleBase, IRequestHandler<CreateRoleCommand, ErrorOr<Role>>
    {
        private readonly IRoleRepository _repository;
        public CreateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Role>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            Role? role = PrepareInputData(request);
            var result = await _repository.AddAsync(role);
            return  result;
        }
        private Role PrepareInputData(CreateRoleCommand request, Role? aclRole = null) 
        {
            if (aclRole == null)
            {
                aclRole = new Role();
                aclRole.CreatedById = AppAuth.GetAuthInfo().UserId;
                aclRole.CreatedAt = DateTime.Now;
            }
            aclRole.Title = request.title;
            aclRole.Name = request.name;
            aclRole.Status = request.status;
            aclRole.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            aclRole.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclRole.UpdatedAt = DateTime.Now;

            return aclRole;
        }
    }

}
