using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace SharedBusiness.Main.Admin.Application.Features.Country.Countries;

public record UpdateCountryCommand(
        uint Id,
        string? Code,
        string? IsoCode,
        string? Name,
        byte Status) : IRequest<ErrorOr<IMT.Domain.Entities.Country>>;

    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Country Code  is required");
            RuleFor(x => x.IsoCode).NotEmpty().WithMessage("Country Code  is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Country Code  is required");
        }
    }

    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, ErrorOr<IMT.Domain.Entities.Country>>
    {
        private readonly IAdminCountryRepository _repository;

        public UpdateCountryCommandHandler(IAdminCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<IMT.Domain.Entities.Country>> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            IMT.Domain.Entities.Country? country = _repository.View(command.Id);
            if (country != null)
            {
                country.Code = command.Code;
                country.IsoCode = command.IsoCode;
                country.Name = command.Name;
                country.Status = command.Status;
                country.UpdatedById = command.Id;
                country.UpdatedAt = DateTime.UtcNow;
                    
                return _repository.Update(country)!;
            }
            else
            {
                return Error.NotFound(description: "Country not found!", code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
        }
    }
