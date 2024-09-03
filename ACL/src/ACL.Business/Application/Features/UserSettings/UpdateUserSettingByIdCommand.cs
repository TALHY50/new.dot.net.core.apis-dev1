using ACL.Business.Application.Features.Users;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Auth.Auth;
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

namespace Admin.Web.Application.Features.Mtts
{

    [Authorize]
    public record UpdateUserSettingByIdCommand(uint id,string app_id,string app_secret)
      : IRequest<ErrorOr<UserSetting>>;


    public class UpdateUserSettingByIdCommandValidator : AbstractValidator<UpdateUserSettingByIdCommand>
    {
        public UpdateUserSettingByIdCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
            RuleFor(r => r.app_id).NotEmpty();
            RuleFor(r => r.app_secret).NotEmpty();
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public class UpdateUserSettingByIdCommandHandler : UserSettingBase, IRequestHandler<UpdateUserSettingByIdCommand, ErrorOr<UserSetting>>
    {
        private readonly IUserSettingRepository _repository;
        public static IHttpContextAccessor HttpContextAccessor;
        private readonly ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext _otherDbContext;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateUserSettingByIdCommandHandler(IUserSettingRepository repository, IGuardAgainstNullUpdate guard, IHttpContextAccessor httpContextAccessor, ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext otherDbContext)
        {
            _repository = repository;
            _guard = guard;
            _otherDbContext = otherDbContext;
            HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            AppAuth.Initialize(HttpContextAccessor, _otherDbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }

        public async Task<ErrorOr<UserSetting>> Handle(UpdateUserSettingByIdCommand command, CancellationToken cancellationToken)
        {
            UserSetting? entity = await _repository.GetByIdAsync(command.id, cancellationToken);
          
            if (entity == null)
            {
                return Error.NotFound(description: "User Setting not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => entity.AppId = value, command.app_id);
            _guard.UpdateIfNotNullOrEmpty(value => entity.AppSecret = value, command.app_secret);


            await _repository.UpdateAsync(entity, cancellationToken);

            return entity;


        }

    }
}
