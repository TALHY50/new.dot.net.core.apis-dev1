using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.InstitutionFunds
{
    public record DeleteInstitutionFundCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteInstitutionFundCommandValidator : AbstractValidator<DeleteInstitutionFundCommand>
    {
        public DeleteInstitutionFundCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteInstitutionFundCommandHandler : InstitutionFundBase, IRequestHandler<DeleteInstitutionFundCommand, ErrorOr<bool>>
    {
        private readonly IInstitutionFundRepository _repository;

        public DeleteInstitutionFundCommandHandler(IInstitutionFundRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteInstitutionFundCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var institutionFund = await _repository.GetByIdAsync(command.id);

                if (institutionFund == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(institutionFund, cancellationToken);

            }

            return true;
        }
    }
}
