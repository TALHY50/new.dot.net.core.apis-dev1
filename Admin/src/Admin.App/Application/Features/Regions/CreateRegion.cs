using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

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
        private readonly IImtRegionRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateRegionCommandHandler(IHttpContextAccessor httpContextAccessor, IImtRegionRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
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

            if (@region == null)
            {
                return Error.NotFound(description: Language.GetMessage(_httpContextAccessor, "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return _repository.Add(@region);
        }
    }
}
