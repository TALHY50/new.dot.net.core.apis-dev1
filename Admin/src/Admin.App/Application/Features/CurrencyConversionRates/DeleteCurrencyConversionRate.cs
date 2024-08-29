using Admin.App.Application.Features.Countries;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.CurrencyConversionRates
{
    public class DeleteCurrencyConversionRateController : ApiControllerBase
    {
        [Tags("CurrencyConversionRate")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteCurrencyConversionRateUrl, Name = Routes.DeleteCurrencyConversionRateName)]

        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint Id)
        {
            var result = await Mediator.Send(new DeleteCurrencyConversionRateCommand(Id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record DeleteCurrencyConversionRateCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeleteCurrencyConversionRateCommandValidator : AbstractValidator<DeleteCurrencyConversionRateCommand>
    {
        public DeleteCurrencyConversionRateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("CurrencyConversionRate ID is required");
        }
    }

    public class DeleteCurrencyConversionRateCommandHandler : IRequestHandler<DeleteCurrencyConversionRateCommand, ErrorOr<bool>>
    {
        private readonly IImtCurrencyConversionRateRepository _repository;

        public DeleteCurrencyConversionRateCommandHandler(IImtCurrencyConversionRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCurrencyConversionRateCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var currencyConversionRate = _repository.View(command.Id);

                if (currencyConversionRate == null)
                {
                    return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "CurrencyConversionRate not found!");
                }

                return _repository.Delete(currencyConversionRate);
            }

            return false;
        }
    }
}
