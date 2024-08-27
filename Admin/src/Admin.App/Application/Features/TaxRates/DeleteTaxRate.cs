using Admin.App.Application.Features.Countries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.TaxRates
{
    public class DeleteTaxRateController : ApiControllerBase
    {
        [Tags("TaxRate")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteTaxRateUrl, Name = Routes.DeleteTaxRateName)]

        public async Task<bool> Delete(DeleteTaxRateCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }
    public record DeleteTaxRateCommand(uint Id) : IRequest<bool>;

    internal sealed class DeleteTaxRateCommandValidator : AbstractValidator<DeleteTaxRateCommand>
    {
        public DeleteTaxRateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("TaxRate ID is required");
        }
    }

    internal sealed class DeleteTaxRateCommandHandler : IRequestHandler<DeleteTaxRateCommand, bool>
    {
        private readonly IImtTaxRateRepository _repository;

        public DeleteTaxRateCommandHandler(IImtTaxRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTaxRateCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var taxRate = _repository.GetByUintId(command.Id);

                if (taxRate != null)
                {
                    return await _repository.DeleteAsync(taxRate);
                }
                return await _repository.DeleteAsync(taxRate);
            }

            return false;
        }
    }

}
