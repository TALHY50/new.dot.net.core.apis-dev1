using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.InstitutionFunds
{
    public class DeleteInstitutionFundController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteInstitutionFundUrl, Name = Routes.DeleteInstitutionFundName)]

        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint Id)
        {
            var result = await Mediator.Send(new DeleteInstitutionFundCommand(Id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record DeleteInstitutionFundCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeleteInstitutionFundCommandValidator : AbstractValidator<DeleteInstitutionFundCommand>
    {
        public DeleteInstitutionFundCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }

    public class DeleteInstitutionFundCommandHandler : IRequestHandler<DeleteInstitutionFundCommand, ErrorOr<bool>>
    {
        private readonly IInstitutionFundRepository _repository;

        public DeleteInstitutionFundCommandHandler(IInstitutionFundRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<bool>> Handle(DeleteInstitutionFundCommand command, CancellationToken cancellationToken)
        {
          if(command.Id > 0)
            {
                var country = await _repository.GetByIdAsync(command.Id);

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
