using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.TaxRates
{
    public record DeleteTaxRateByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteTaxRateByIdCommandValidator : AbstractValidator<DeleteTaxRateByIdCommand>
    {
        public DeleteTaxRateByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteTaxRateByIdCommandHandler : TaxRateBase, IRequestHandler<DeleteTaxRateByIdCommand, ErrorOr<bool>>
    {
        private readonly ITaxRateRepository _repository;

        public DeleteTaxRateByIdCommandHandler(ITaxRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteTaxRateByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var taxRate = await _repository.GetByIdAsync(command.id);

                if (taxRate == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(taxRate, cancellationToken);

            }

            return true;
        }
    }
}
