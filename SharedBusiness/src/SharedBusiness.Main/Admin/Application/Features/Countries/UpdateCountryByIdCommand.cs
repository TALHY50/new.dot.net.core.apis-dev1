using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Countries;

public record UpdateCountryByIdCommand(
        uint id,
        string? iso_code,
        string? iso_code_short,
        string? iso_code_num,
        string? name,
        string? official_state_name,
        StatusValues status) : IRequest<ErrorOr<Common.Domain.Entities.Country>>;

    public class UpdateCountryByIdCommandValidator : AbstractValidator<UpdateCountryByIdCommand>
    {
        public UpdateCountryByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Country ID is required");
            RuleFor(x => x.iso_code).IsoCountryCode();
            RuleFor(x => x.iso_code_short).IsoCountryCodeShort();
            RuleFor(x => x.iso_code_num).IsoCountryCodeNum();
            RuleFor(x => x.status).IsInEnum();
            RuleFor(x => x.name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.official_state_name).NotEmpty().MaximumLength(100);
        }
    }

    public class UpdateCountryByIdCommandHandler : CountryBase, IRequestHandler<UpdateCountryByIdCommand, ErrorOr<Common.Domain.Entities.Country>>
    {
        private readonly ICountryRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateCountryByIdCommandHandler(ICountryRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<Common.Domain.Entities.Country>> Handle(UpdateCountryByIdCommand command, CancellationToken cancellationToken)
        {
            Common.Domain.Entities.Country? country = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (country == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }
            
            
            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => country.IsoCode = value, command.iso_code);
            _guard.UpdateIfNotNullOrEmpty(value => country.IsoCodeShort = value, command.iso_code_short);
            _guard.UpdateIfNotNullOrEmpty(value => country.IsoCodeNum = value, command.iso_code_num);
            _guard.UpdateIfNotNullOrEmpty(value => country.Name = value, command.name);
            _guard.UpdateIfNotNullOrEmpty(value => country.OfficialStateName = value, command.official_state_name);
            
            country.UpdatedAt = DateTime.UtcNow;
                
            await _repository.UpdateAsync(country, cancellationToken);
            
            return country;


        }
            
    }
    
