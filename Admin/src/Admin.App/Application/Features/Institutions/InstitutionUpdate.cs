using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using static Admin.App.Application.Features.Mtts.MttsCreate;

namespace Admin.App.Application.Features.Institutions
{
    public class InstitutionUpdate : ApiControllerBase
    {
        [Tags("Institution")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateInstitutionUrl, Name = Routes.UpdateInstitutionName)]
        public async Task<ActionResult<ErrorOr<Institution>>> Update(uint id, UpdateInstitutionCommand command)
        {
            var commandWithId = command with { id = id };
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }

        public record UpdateInstitutionCommand(uint id, string? Name, string? Url, uint? CompanyId, byte Status)
          : IRequest<ErrorOr<Institution>>;


        public class UpdateInstitutionCommandValidator : AbstractValidator<UpdateInstitutionCommand>
        {
            public UpdateInstitutionCommandValidator()
            {
             RuleFor(r => r.Status).NotEmpty().WithMessage("Status is required.");
            }
        }

        public class UpdateInstitutionCommandHandler(ApplicationDbContext context, IInstitutionRepository repository, IInstitutionSettingRepository institutionSettingRepository, ICurrentUserService user) : IRequestHandler<UpdateInstitutionCommand, ErrorOr<Institution>>
        {
            public async Task<ErrorOr<Institution>> Handle(UpdateInstitutionCommand request, CancellationToken cancellationToken)
            {
                Institution? entity = repository.View(request.id);
                if (entity != null)
                {
                    entity.Name = request.Name;
                    entity.Url = request.Url;
                    entity.CompanyId = request.CompanyId;
                    entity.Status = request.Status;
                    entity.UpdatedById = uint.Parse(user?.UserId ?? "1");
                    entity.UpdatedAt = DateTime.UtcNow;
                }

                return  repository.Update(entity);
            }
        }
    }
}
