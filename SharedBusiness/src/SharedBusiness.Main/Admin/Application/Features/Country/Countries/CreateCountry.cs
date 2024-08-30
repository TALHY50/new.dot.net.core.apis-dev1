using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace SharedBusiness.Main.Admin.Application.Features.Country.Countries
{
    public record CreateCountryCommand(
        string? Code,
        string? IsoCode,
        string? Name,
        //uint? CreatedById,
        //uint? UpdatedById,
        byte Status
        ) : IRequest<ErrorOr<IMT.Domain.Entities.Country>>;

    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Country Code  is required");
            RuleFor(x => x.IsoCode).NotEmpty().WithMessage("Country Code  is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Country Code  is required");
        }
    }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, ErrorOr<IMT.Domain.Entities.Country>>
    {
        private readonly IAdminCountryRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateCountryCommandHandler(IHttpContextAccessor httpContextAccessor, IAdminCountryRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<ErrorOr<IMT.Domain.Entities.Country>> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            var country = new IMT.Domain.Entities.Country
            {
                Code = command.Code,
                IsoCode = command.IsoCode,
                Name = command.Name,
                CreatedById = 1,
                UpdatedById = 1,
                Status = 1, //1=active, 0=inactive, 2=soft-deleted
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var message = new MessageResponse("Record not found");

            if (country == null)
            {
                return Error.NotFound(description: Language.GetMessage(_httpContextAccessor, "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            return _repository.Add(country)!;
        }
    }
}
