using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;

namespace SharedBusiness.Main.Admin.Application.Features.Country.Countries
{
    public record DeleteCountryCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
        }
    }

    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, ErrorOr<bool>>
    {
        private readonly IAdminCountryRepository _repository;

        public DeleteCountryCommandHandler(IAdminCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
        {
            var message = new MessageResponse("Record not found");
            if (command.Id > 0)
            {
                var country = _repository.View(command.Id);

                if (country == null)
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _repository.Delete(country);
            }

            return false;
        }
    }
}
