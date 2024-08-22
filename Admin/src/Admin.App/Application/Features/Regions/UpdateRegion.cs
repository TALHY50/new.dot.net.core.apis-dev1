using ADMIN.Application.Infrastructure.Persistence.Configurations;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;


namespace ADMIN.App.Application.Features.Regions
{
    public class UpdateRegionController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateRegionUrl, Name = Routes.UpdateRegionName)]
        public async Task<ActionResult<ErrorOr<Region>>> Update(UpdateRegionCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

    }

    public record UpdateRegionCommand(
        int Id,
        string? Name,
        sbyte Status = 1) : IRequest<ErrorOr<Region>>;

    internal sealed class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
    {
        public UpdateRegionCommandValidator()
        {
            RuleFor(v => v.Status)
                .NotEmpty()
                .WithMessage("Status is required.");
        }
    }

    internal sealed class UpdateRegionCommandHandler(ApplicationDbContext context) 
        : IRequestHandler<UpdateRegionCommand, ErrorOr<Region>>
    {
        

        public async Task<ErrorOr<Region>> Handle(UpdateRegionCommand command, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @region = new Region
            {
                Name = command.Name,
                CompanyId = 0,
                Status = 1,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };

            //_context.Countries.Add(@country);

            //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return @region;
        }
    }
}

