using ACL.Business.Application;
using ACL.Business.Application.Features.Users;
using ACL.Business.Application.Features.UserSettings;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using Admin.Web.Presentation.Routes;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.Institutions
{
    public class CreateInstitution : ApiControllerBase
    {
        [Tags("Institution")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(InstitutionRoutes.CreateInstitutionUrl, Name = InstitutionRoutes.CreateInstitutionName)]
        public async Task<ActionResult<ErrorOr<Institution>>> Create(CreateInstitutionCommand command)
        {
            var result = await Mediator.Send(command.InstitutionCommand).ConfigureAwait(false);
            var user = await Mediator.Send(command.UserCommand).ConfigureAwait(false);
            //CreateUserSettingCommand userSettingCommand = new CreateUserSettingCommand("sdsdgsdg", "sdsgsdg");
            //var user_setting = await Mediator.Send(command.UserSettingCommand).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(new { Institution = result.Value, Setting = user_setting.Value }),
                Problem);
        }
    }
    public class CreateCombinedInstitutionCommand
    {
        public CreateInstitutionCommand InstitutionCommand { get; set; }
        public CreateUserCommand UserCommand { get; set; }
    }
    public record CreateInstitutionCommand(string? name, string? url, uint? company_id, byte status,
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
    uint[]? user_group,
    string? salt)
        : IRequest<ErrorOr<Institution>>;

    public class CreateInstitutionCommandValidator : AbstractValidator<CreateInstitutionCommand>
    {
        public CreateInstitutionCommandValidator()
        {
            RuleFor(r => r.status).NotEmpty().WithMessage("Status is required.");
            RuleFor(r => r.email).NotEmpty().WithMessage("Email is required.");
        }
    }

    public class CreateInstitutionHandler(ApplicationDbContext context, IInstitutionRepository repository, IInstitutionSettingRepository institutionSettingRepository, ICurrentUser user, IUserService userServiceRepository, IUserSettingRepository userSettingRepository) : IRequestHandler<CreateInstitutionCommand, ErrorOr<Institution>>
    {
        public async Task<ErrorOr<Institution>> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Institution
            {
                Name = request.name,
                Url = request.url,
                CompanyId = request.company_id,
                Status = request.status,
                CreatedById = uint.Parse(user?.UserId ?? "1"),
                UpdatedById = uint.Parse(user?.UserId ?? "1"),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var result = await repository.AddAsync(entity);
            var userRequest = new AclUserRequest
            {
                FirstName = result.Name,
                LastName = result.Name,
                Email = request.email,
                Language = "en-US",
                Avatar = result.Url,
                Password = "Srbl@123.",
                Gender = 1,
                Status = 1,
                UserGroup = new uint[] { 2 },
                UserName = result.Name
            };
            await userServiceRepository.AddUser(userRequest);
            var newUserSetting = new UserSetting
            {
                AppId = request.email,
                AppSecret = "Srbl@123."
            };
            await userSettingRepository.AddAsync(newUserSetting);
            return result;
        }
    }
}
