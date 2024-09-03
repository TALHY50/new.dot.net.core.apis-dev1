
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Currencies;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Corridors
{
    public record UpdateCorridorByIdCommand(
        uint id,
        uint? SourceCountryId,
        uint? DestinationCountryId,
        uint? SourceCurrencyId,
        uint? DestinationCurrencyId,
        uint? CompanyId,
        StatusValues Status) : IRequest<ErrorOr<Corridor>>;

    public class UpdateCorridorByIdCommandValidator : AbstractValidator<UpdateCorridorByIdCommand>
    {
        public UpdateCorridorByIdCommandValidator()
        {
            RuleFor(x => x.SourceCountryId).NotEmpty();
            RuleFor(x => x.DestinationCountryId).NotEmpty();
            RuleFor(x => x.SourceCurrencyId).NotEmpty();
            RuleFor(x => x.DestinationCurrencyId).NotEmpty();
        }
    }

    public class UpdateCorridorByIdCommandHandler : CorridorBase, IRequestHandler<UpdateCorridorByIdCommand, ErrorOr<Corridor>>
    {
        private readonly ICorridorRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateCorridorByIdCommandHandler(ICorridorRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<Corridor>> Handle(UpdateCorridorByIdCommand command, CancellationToken cancellationToken)
        {
            Corridor? corridor = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (corridor == null)
            {
                return Error.NotFound(description: "Corridor not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => corridor.SourceCountryId = value, command.SourceCountryId);
            _guard.UpdateIfNotNullOrEmpty(value => corridor.DestinationCountryId = value, command.DestinationCountryId);
            _guard.UpdateIfNotNullOrEmpty(value => corridor.SourceCurrencyId = value, command.SourceCurrencyId);
            _guard.UpdateIfNotNullOrEmpty(value => corridor.DestinationCurrencyId = value, command.DestinationCurrencyId);

            corridor.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(corridor, cancellationToken);

            return corridor;


        }

    }
}
