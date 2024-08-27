using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;


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
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }

        public record UpdateRegionCommand(
        uint id,
        string? Name
        ) : IRequest<ErrorOr<Region>>;

        //internal sealed class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
        //{
        //    public UpdateRegionCommandValidator()
        //    {
        //        RuleFor(v => v.Status)
        //            .NotEmpty()
        //            .WithMessage("Status is required.");
        //    }
        //}


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

