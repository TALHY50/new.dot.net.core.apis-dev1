using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

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
        private readonly IImtInstitutionFundRepository _repository;

        public DeleteInstitutionFundCommandHandler(IImtInstitutionFundRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<bool>> Handle(DeleteInstitutionFundCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var institutionFund = _repository.View(command.Id);

                if(institutionFund == null)
                {
                    return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "Institution Fund not found!");

                }

                return _repository.Delete(institutionFund);
            }

            return false;
        }
    }
}
