using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Application.Features.Regions
{
    public class CreateRegionController : ApiControllerBase
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateRegionUrl, Name = Routes.CreateRegionName)]
        public async Task<ActionResult<ErrorOr<Region>>> Create(CreateRegionCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreateRegionCommand(
        string? Name,
        uint? CompanyId,
        byte Status) : IRequest<ErrorOr<Region>>;

    public class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
    {
        public CreateRegionCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(50)
                .WithMessage("Maximum length can be 50.");
            RuleFor(v => v.Status)
                .NotEmpty()
                .WithMessage("Status is required.");
        }
    }

    public class CreateRegionCommandHandler
        : IRequestHandler<CreateRegionCommand, ErrorOr<Region>>
    {
        private readonly IRegionRepository _repository;
        public CreateRegionCommandHandler(IRegionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Region>> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @region = new Region
            {
                Name = request.Name,
                CompanyId = request.CompanyId??1,
                Status = request.Status,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now
            };

            return _repository.Add(@region);
        }
    }
}
