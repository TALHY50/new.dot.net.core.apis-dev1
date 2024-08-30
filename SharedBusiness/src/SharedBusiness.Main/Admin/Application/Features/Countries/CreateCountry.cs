using System.Data;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Enums;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Infrastructure.Extensions;
using SharedKernel.Main.Infrastructure.Extensions.Rules;

namespace SharedBusiness.Main.Admin.Application.Features.Countries
{
    
    public record CreateCountryCommand(
        string? name,
        string? official_state_name,
        string? iso_code,
        string? iso_code_short,
        string? iso_code_num,
        StatusValues status
        ) : IRequest<ErrorOr<Country>>;

    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(x => x.iso_code).IsoCountryCode();
            RuleFor(x => x.iso_code_short).IsoCountryCodeShort();
            RuleFor(x => x.iso_code_num).IsoCountryCodeNum();
            RuleFor(x => x.name).MaximumLength(100);
            RuleFor(x => x.official_state_name).MaximumLength(100);
            RuleFor(x => x.status).IsInEnum();
        }
    }

    public class CreateCountryCommandHandler : CountryBase, IRequestHandler<CreateCountryCommand, ErrorOr<Common.Domain.Entities.Country>>
    {
        private readonly ICountryRepository _repository;

        public CreateCountryCommandHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Common.Domain.Entities.Country>> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            var country = new Common.Domain.Entities.Country
            {
                Name = command.name,
                OfficialStateName = command.official_state_name,
                IsoCode = command.iso_code,
                IsoCodeShort = command.iso_code_short,
                IsoCodeNum = command.iso_code_num,
                CreatedById = 0,
                UpdatedById = 0,
                Status = (int) command.status, //1=active, 0=inactive, 2=soft-deleted
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var result = _repository.Add(country);

            if (result == null)
            {
                return Error.Unexpected(ApplicationStatusCodes.API_ERROR_UNEXPECTED_ERROR,
                    "Country could not be added");
            }

            return result;


        }
    }
    
}
