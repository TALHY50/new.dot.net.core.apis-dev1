using ACL.App.Contracts.Responses;
using Admin.App.Application.Features.Countries;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.TaxRates
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
        private readonly IImtTaxRateRepository _repository;

        public DeleteTaxRateCommandHandler(IImtTaxRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteTaxRateCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var taxRate = _repository.View(command.Id);

                var message = new MessageResponse("Record not found");

                if (taxRate == null)
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
                return _repository.Delete(taxRate);
            }

            return false;
        }
    }

}
