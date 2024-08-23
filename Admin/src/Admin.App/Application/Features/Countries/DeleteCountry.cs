using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Context;

namespace Admin.App.Application.Features.Countries
{
    public class DeleteCountryController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteCountryUrl, Name = Routes.DeleteCountryName)]

        public async Task<ActionResult<ErrorOr<Country>>> Delete(DeleteCountryCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record DeleteCountryCommand(int Id) : IRequest<ErrorOr<Country>>;

    internal sealed class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
        }
    }

    internal sealed class DeleteCountryCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteCountryCommand, ErrorOr<Country>>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ErrorOr<Country>> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }



}
