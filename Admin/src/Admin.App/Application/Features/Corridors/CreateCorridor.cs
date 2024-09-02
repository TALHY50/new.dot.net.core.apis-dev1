using Admin.App.Application.Features.Currencies;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.Corridors
{
    public class CreateCorridorController : ApiControllerBase
    {
        [Tags("Corridor")]
        //[Authorize]
        [HttpPost(Routes.CreateCorridorUrl, Name = Routes.CreateCorridorName)]
        public async Task<ActionResult<ErrorOr<Corridor>>> Create(CreateCorridorCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreateCorridorCommand(
        uint? SourceCountryId,
        uint? DestinationCountryId,
        uint? SourceCurrencyId,
        uint? DestinationCurrencyId,
        uint? CompanyId) : IRequest<ErrorOr<Corridor>>;

    public class CreateCorridoryCommandValidator : AbstractValidator<CreateCorridorCommand>
    {
        public CreateCorridoryCommandValidator()
        {
            RuleFor(x => x.SourceCountryId).NotEmpty();
            RuleFor(x => x.DestinationCountryId).NotEmpty();
            RuleFor(x => x.SourceCurrencyId).NotEmpty();
            RuleFor(x => x.DestinationCurrencyId).NotEmpty();
        }
    }

    public class CreateCorridorCommandHandler : IRequestHandler<CreateCorridorCommand, ErrorOr<Corridor>>
    {
        private readonly ICorridorRepository _repository;

        public CreateCorridorCommandHandler(ICorridorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Corridor>> Handle(CreateCorridorCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @corridor = new Corridor
            {
                SourceCountryId = request.SourceCountryId,
                DestinationCountryId = request.DestinationCountryId,
                SourceCurrencyId = request.SourceCurrencyId,
                DestinationCurrencyId = request.DestinationCurrencyId,
                CompanyId = request.CompanyId,
                CreatedById = 1,
                UpdatedById = 2,
                Status = 1,
                CreatedAt = now,
                UpdatedAt = now,
            };
            var result = _repository.Add(@corridor);

            if (result == null)
            {
                return Error.Unexpected(ApplicationStatusCodes.API_ERROR_UNEXPECTED_ERROR.ToString(),
                    "Corridor not found");
            }
            return result;
        }
    }
}
