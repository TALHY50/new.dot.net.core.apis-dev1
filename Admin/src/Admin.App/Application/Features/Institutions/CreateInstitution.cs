﻿using ACL.Business.Application;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
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
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.Institutions
{
    public class CreateInstitution : ApiControllerBase
    {
        [Tags("Institution")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateInstitutionUrl, Name = Routes.CreateInstitutionName)]
        public async Task<ActionResult<ErrorOr<Institution>>> Create(CreateInstitutionCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreateInstitutionCommand(string? Name, string? Url, uint? CompanyId, byte Status)
        : IRequest<ErrorOr<Institution>>;

    public class CreateInstitutionCommandValidator : AbstractValidator<CreateInstitutionCommand>
    {
        public CreateInstitutionCommandValidator()
        {
            RuleFor(r => r.Status).NotEmpty().WithMessage("Status is required.");
        }
    }

    public class CreateInstitutionHandler(ApplicationDbContext context, IInstitutionRepository repository, IInstitutionSettingRepository institutionSettingRepository, ICurrentUser user) : IRequestHandler<CreateInstitutionCommand, ErrorOr<Institution>>
    {
        public async Task<ErrorOr<Institution>> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Institution
            {
                Name = request.Name,
                Url = request.Url,
                CompanyId = request.CompanyId,
                Status = request.Status,
                CreatedById = uint.Parse(user?.UserId ?? "1"),
                UpdatedById = uint.Parse(user?.UserId ?? "1"),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var result = repository.Add(entity);
            var setting = new InstitutionAppSetting
            {
                InstitutionId = result.Id,
                AppName = result.Name,
                AppId = "dgdgfdgh", // Hard Coded
                AppSecret = "dfgdfg", // Hard Coded
                Token = "token", // Hard Coded
                Status = result.Status,
                CreatedById = uint.Parse(user?.UserId ?? "1"),
                UpdatedById = uint.Parse(user?.UserId ?? "1"),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            institutionSettingRepository.Add(setting);
            return result;
        }
    }
}
