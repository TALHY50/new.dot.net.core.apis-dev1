using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

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
        private readonly ICurrencyConversionRateRepository _repository;
        public DeleteCurrencyConversionRateCommandHandler(ICurrencyConversionRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCurrencyConversionRateCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var currencyConversionRate = _repository.View(command.Id);
                var message = new MessageResponse("Record not found");

                if (currencyConversionRate == null)
                {
                    return Error.NotFound(description: Language.GetMessage("Record not found"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _repository.Delete(currencyConversionRate);
            }

            return false;
        }
    }
}
