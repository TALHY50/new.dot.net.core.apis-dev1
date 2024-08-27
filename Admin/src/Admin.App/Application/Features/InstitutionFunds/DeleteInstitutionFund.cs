using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;

namespace Admin.App.Application.Features.InstitutionFunds
{
    public class DeleteInstitutionFundController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteInstitutionFundUrl, Name = Routes.DeleteInstitutionFundName)]

        public async Task<ActionResult<bool>> Delete(DeleteInstitutionFundCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }
    public record DeleteInstitutionFundCommand(int Id) : IRequest<bool>;

    internal sealed class DeleteInstitutionFundCommandValidator : AbstractValidator<DeleteInstitutionFundCommand>
    {
        public DeleteInstitutionFundCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }

    internal sealed class DeleteInstitutionFundCommandHandler : IRequestHandler<DeleteInstitutionFundCommand, bool>
    {
        private readonly IImtInstitutionFundRepository _repository;

        public DeleteInstitutionFundCommandHandler(IImtInstitutionFundRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteInstitutionFundCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var institutionFund = _repository.GetByIntId(command.Id);

                if (institutionFund != null)
                {
                    return await _repository.DeleteAsync(institutionFund);
                }

                return await _repository.DeleteAsync(institutionFund);
            }

            return false;
        }
    }
}
