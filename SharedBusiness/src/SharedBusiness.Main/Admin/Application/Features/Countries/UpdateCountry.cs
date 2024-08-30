using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Enums;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Infrastructure.Extensions.Rules;

namespace SharedBusiness.Main.Admin.Application.Features.Countries;

public record UpdateCountryCommand(
        uint id,
        string? iso_code,
        string? iso_code_short,
        string? iso_code_num,
        string? name,
        string? official_state_name,
        StatusValues status) : IRequest<ErrorOr<Common.Domain.Entities.Country>>;

    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryCommandValidator()
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

    public class UpdateCountryCommandHandler : CountryBase, IRequestHandler<UpdateCountryCommand, ErrorOr<Common.Domain.Entities.Country>>
    {
        private readonly ICountryRepository _repository;

        public UpdateCountryCommandHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Common.Domain.Entities.Country>> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            Common.Domain.Entities.Country? country = _repository.GetById(command.id);
            if (country == null)
            {
                return Error.NotFound(description: "Country not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            
            country.IsoCode = command.iso_code;
            country.IsoCodeShort = command.iso_code_short;
            country.IsoCodeNum = command.iso_code_num;
            country.Name = command.name;
            country.OfficialStateName = command.official_state_name;
            country.Status = (sbyte) command.status;
            country.UpdatedAt = DateTime.UtcNow;
                
            var result =  _repository.Update(country);

            if (result == null)
            {
                return Error.NotFound(ApplicationStatusCodes.API_ERROR_UNEXPECTED_ERROR, "Country can not be updated");
            }

            return result;


        }
            
    }
    
