using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using static Admin.App.Application.Features.Regions.GetRegionByIdController;


namespace Admin.App.Application.Features.Regions
{
    public class UpdateRegionController : ApiControllerBase
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateRegionUrl, Name = Routes.UpdateRegionName)]
        public async Task<ActionResult<ErrorOr<Region>>> Update(uint id, UpdateRegionCommand command)
        {
            var commandWithId = command with { id = id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record UpdateRegionCommand(
        uint id,
        string? Name,
        uint? CompanyId,
        byte Status) : IRequest<ErrorOr<Region>>;

        internal sealed class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
        {
            public UpdateRegionCommandValidator()
            {
                RuleFor(v => v.id)
                    .NotEmpty()
                    .WithMessage("ID is required.");
                RuleFor(v => v.Name)
                .MaximumLength(50)
                .WithMessage("Maximum length can be 50.");
                RuleFor(v => v.Status)
                    .NotEmpty()
                    .WithMessage("Status is required.");
            }
        }


        internal sealed class UpdateRegionCommandHandler
        : IRequestHandler<UpdateRegionCommand, ErrorOr<Region>>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtRegionRepository _repository;

            public UpdateRegionCommandHandler(ICurrentUserService user, IImtRegionRepository repository)
            {
                _user = user;
                _repository = repository;
            }

            public async Task<ErrorOr<Region>> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
            {
                var now = DateTime.UtcNow;
                Region? regions = _repository.GetByUintId(request.id);
                if (regions != null)
                {
                    regions.Name = request.Name;
                    regions.CompanyId = 0;
                    regions.Status = 1;
                    regions.CreatedById = 1;
                    regions.UpdatedById = 2;
                    regions.CreatedAt = now;
                    regions.UpdatedAt = now;
                };

                

                return await _repository.UpdateAsync(regions);
            }
        }

    }
}

