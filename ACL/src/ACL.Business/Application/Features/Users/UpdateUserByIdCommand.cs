using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace ACL.Business.Application.Features.Users
{

    [Authorize]
    public record UpdateUserByIdCommand(uint id,

    string? first_name,
    string? last_name,
    string? email,
    string? avatar,
    string? language,
    string? password,
    DateTime? dob,
    sbyte? gender,
    string? address,
    string? city,
    uint? country,
    string? phone,
    string? user_name,
    string? img_path,
    sbyte? status,
    uint[]? user_group,
    string? salt)
      : IRequest<ErrorOr<User>>;


    public class UpdateUserByIdCommandValidator : AbstractValidator<UpdateUserByIdCommand>
    {
        public UpdateUserByIdCommandValidator()
        {
            RuleFor(x => x.status).NotEmpty().IsInEnum();
        }
    }



        [ApiExplorerSettings(IgnoreApi = true)]
    public class UpdateUserByIdCommandHandler : UserBase, IRequestHandler<UpdateUserByIdCommand, ErrorOr<User>>
    {

        private readonly IUserService _repository;
        public static IHttpContextAccessor HttpContextAccessor;
        private readonly ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext _otherDbContext;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateUserByIdCommandHandler(IUserService repository, IGuardAgainstNullUpdate guard, IHttpContextAccessor httpContextAccessor, ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext otherDbContext)
        {
            _repository = repository;
            _guard = guard;
            _otherDbContext = otherDbContext;
            HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            AppAuth.Initialize(HttpContextAccessor, _otherDbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }


        public async Task<ErrorOr<User>> Handle(UpdateUserByIdCommand command, CancellationToken cancellationToken)
        {
            User? entity = await _repository.GetByIdAsync(command.id, cancellationToken);

            if (entity == null)
            {
                return Error.NotFound(description: "User not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            entity.UpdatedAt = DateTime.UtcNow;
            var userRequest  = new AclUserRequest
            {
                FirstName = command.first_name,
                LastName = command.last_name,
                Email = command.email,
                Avatar = command.avatar,
                Language = command.language,
                Password = command.password,
                DOB = command.dob,
                Gender = (sbyte)command.gender,
                Address = command.address,
                City = command.city,
                Country = (uint)command.country,
                ImgPath = command.img_path,
                Phone = command.phone,
                Status = (sbyte)command.status,
               UserName = command.user_name,
               UserGroup = command.user_group
            };
            await _repository.Edit(command.id,userRequest);

            return entity;


        }

    }
}
