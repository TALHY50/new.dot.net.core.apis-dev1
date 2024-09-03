using ACL.Business.Application;
using ACL.Business.Application.Features.Users;
using ACL.Business.Application.Features.UserSettings;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Auth.Auth;
using Admin.Web.Presentation.Routes;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Admin.Web.Presentation.Endpoints.Institutions
{
    public class CreateInstitution : ApiControllerBase
    {
        [Tags("Institution")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(InstitutionRoutes.CreateInstitutionUrl, Name = InstitutionRoutes.CreateInstitutionName)]
        public async Task<ActionResult<ErrorOr<InstitutionResult>>> Create(CreateInstitutionCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public class CreateCombinedInstitutionCommand
    {
        public CreateInstitutionCommand InstitutionCommand { get; set; }
        public CreateUserCommand UserCommand { get; set; }
    }
    public record CreateInstitutionCommand(string? name, string? url, uint? company_id, StatusValues status,
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
        : IRequest<ErrorOr<InstitutionResult>>;

    public class CreateInstitutionCommandValidator : AbstractValidator<CreateInstitutionCommand>
    {
        public CreateInstitutionCommandValidator()
        {
            RuleFor(r => r.status).IsInEnum();
        }
    }
    public class InstitutionResult
    {
        public Institution Institution { get; set; }
        public UserSetting UserSetting { get; set; }
    }
    public class CreateInstitutionHandler : ControllerBase, IRequestHandler<CreateInstitutionCommand, ErrorOr<InstitutionResult>>
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        private readonly IInstitutionRepository _repository;
        private readonly IInstitutionSettingRepository _institutionSettingRepository;
        private readonly ICurrentUser _user;
        private readonly IUserService _userServiceRepository;
        private readonly IUserSettingRepository _userSettingRepository;
        private readonly ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext _otherDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateInstitutionHandler(
            ApplicationDbContext context,
            IInstitutionRepository repository,
            IInstitutionSettingRepository institutionSettingRepository,
            ICurrentUser user,
            IUserService userServiceRepository,
            IUserSettingRepository userSettingRepository,
            ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext otherDbContext,
            IHttpContextAccessor httpContextAccessor,
            IMediator mediator) // Inject the IMediator here
        {
            _context = context;
            _repository = repository;
            _institutionSettingRepository = institutionSettingRepository;
            _user = user;
            _userServiceRepository = userServiceRepository;
            _userSettingRepository = userSettingRepository;
            _otherDbContext = otherDbContext;
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<ErrorOr<InstitutionResult>> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
        {
            var idGenerator = new IdGenerator();
            string generatedId;
            var user = _userServiceRepository.FindByEmail(generatedId = idGenerator.GenerateRandomId(6).ToString());

            while (user != null)
            {
                generatedId = idGenerator.GenerateRandomId().ToString();
                user = _userServiceRepository.FindByEmail(generatedId);
            }

            var entity = new Institution
            {
                Name = request.name,
                Url = request.url,
                CompanyId = request.company_id,
                Status = (byte)request.status,
                CreatedById = AppAuth.GetAuthInfo().UserId,
                UpdatedById = AppAuth.GetAuthInfo().UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _repository.AddAsync(entity);

            CreateUserCommand cmd = new CreateUserCommand
            (
                 request.first_name,
                 request.last_name,
                 generatedId,
                 request.avatar,
                 request.language,
                  request.password,
                 request.dob,
                  request.gender,
                 request.address,
                 request.city,
                 request.country,
                 request.phone,
                 request.user_name,
                 request.img_path,
                 (byte)request.status,
            new uint[] { 2 },
            request.salt
            );

            var resul = await _mediator.Send(cmd).ConfigureAwait(false);


            var newUserSetting = new UserSetting
            {
                Id = resul.Value.Id,
                UserId = resul.Value.Id,
                AppId = generatedId,
                AppSecret = "Srbl@123."
            };

            await _userSettingRepository.AddAsync(newUserSetting);

            // Return the combined result
            return new InstitutionResult
            {
                Institution = result,
                UserSetting = newUserSetting
            };
        }

    }
}
