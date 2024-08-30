using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace SharedBusiness.Main.Admin.Application.Features.Countries
{
    
    public record DeleteCountryCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteCountryCommandHandler : CountryBase, IRequestHandler<DeleteCountryCommand, ErrorOr<bool>>
    {
        private readonly ICountryRepository _repository;

        public DeleteCountryCommandHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
        {
            if(command.id > 0)
            {
                var country = _repository.GetById(command.id);

                if (country == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Country not found");
                }

                var result =  _repository.Delete(country);

                if ( ! result)
                {
                    return Error.Unexpected(code: ApplicationStatusCodes.API_ERROR_UNEXPECTED_ERROR,
                        "Failed to delete the record");
                }

                return result;
            }

            return false;
        }
    }
}
