using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Countries
{
    
    public record DeleteCountryByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteCountryByIdCommandValidator : AbstractValidator<DeleteCountryByIdCommand>
    {
        public DeleteCountryByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteCountryByIdCommandHandler : CountryBase, IRequestHandler<DeleteCountryByIdCommand, ErrorOr<bool>>
    {
        private readonly ICountryRepository _repository;

        public DeleteCountryByIdCommandHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCountryByIdCommand command, CancellationToken cancellationToken)
        {
            if(command.id > 0)
            {
                var country = await _repository.GetByIdAsync(command.id);

                if (country == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Country not found");
                }

                await _repository.DeleteAsync(country, cancellationToken);
                
            }

            return true;
        }
    }
}
