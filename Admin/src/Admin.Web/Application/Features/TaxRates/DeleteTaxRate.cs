using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.TaxRates
{
    public class DeleteTaxRateController : ApiControllerBase
    {
        [Tags("TaxRate")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteTaxRateUrl, Name = Routes.DeleteTaxRateName)]

        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint Id)
        {
            var result = await Mediator.Send(new DeleteTaxRateCommand(Id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record DeleteTaxRateCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeleteTaxRateCommandValidator : AbstractValidator<DeleteTaxRateCommand>
    {
        public DeleteTaxRateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("TaxRate ID is required");
        }
    }

    public class DeleteTaxRateCommandHandler : IRequestHandler<DeleteTaxRateCommand, ErrorOr<bool>>
    {
        private readonly ITaxRateRepository _repository;

        public DeleteTaxRateCommandHandler(ITaxRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteTaxRateCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var taxRate = await _repository.GetByIdAsync(command.Id);

                if (taxRate == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Tax Rate not found!");
                }
                await _repository.DeleteAsync(taxRate);
                return true;
            }

            return false;
        }
    }

}
