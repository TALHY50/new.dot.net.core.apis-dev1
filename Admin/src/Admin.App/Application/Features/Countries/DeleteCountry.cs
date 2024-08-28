using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.Countries
{
    public class DeleteCountryController : ApiControllerBase
    {
        [Tags("Country")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteCountryUrl, Name = Routes.DeleteCountryName)]

        public async Task<bool> Delete(DeleteCountryCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record DeleteCountryCommand(uint Id) : IRequest<bool>;

    internal sealed class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
        }
    }

    internal sealed class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, bool>
    {
        private readonly IAdminCountryRepository _repository;

        public DeleteCountryCommandHandler(IAdminCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
        {
            if(command.Id > 0)
            {
                var country = _repository.GetByUintId(command.Id);

                if(country != null)
                {
                    return await _repository.DeleteAsync(country);
                }
                return await _repository.DeleteAsync(country!);
            }

            return false;
        }
    }
}
