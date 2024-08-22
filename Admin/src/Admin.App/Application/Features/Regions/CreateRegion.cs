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
    public class CreateRegionController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateRegionUrl, Name = Routes.CreateRegionName)]
        public async Task<ActionResult<ErrorOr<Region>>> Create(CreateRegionCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreateRegionCommand(
        string Name,
        sbyte Status=1) : IRequest<ErrorOr<Region>>;

    internal sealed class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
    {
        public CreateRegionCommandValidator()
        {
            RuleFor(v => v.Status)
                .NotEmpty()
                .WithMessage("Status is required.");
        }
    }

    internal sealed class CreateRegionCommandHandler(ApplicationDbContext context) 
        : IRequestHandler<CreateRegionCommand, ErrorOr<Region>>
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<ErrorOr<Region>> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @region = new Region
            {
                Name = request.Name,
                CompanyId = 0,
                Status = 1,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now,
            };
           // _context.Events.Add(@region);

            return region;
        }
    }
}
