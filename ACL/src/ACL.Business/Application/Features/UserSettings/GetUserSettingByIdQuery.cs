using ACL.Business.Application.Features.Users;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace ACL.Business.Application.Features.UserSettings
{
    [Authorize]
    public record GetUserSettingByIdQuery(ulong id) : IRequest<ErrorOr<UserSetting>>;

    public class GetUserSettingByIdQueryValidator : AbstractValidator<GetUserSettingByIdQuery>
    {
        public GetUserSettingByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("User Setting ID is required");
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public class GetUserSettingByIdQueryHandler :  IRequestHandler<GetUserSettingByIdQuery, ErrorOr<UserSetting>>
    {
        private readonly IUserSettingRepository _repository;

        public GetUserSettingByIdQueryHandler(IUserSettingRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<UserSetting>> Handle(GetUserSettingByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (entity == null)
            {
                return Error.NotFound(description: "User Setting not found!", code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return entity;
        }
    }
}
