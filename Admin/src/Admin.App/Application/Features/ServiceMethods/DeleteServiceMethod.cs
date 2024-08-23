using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class DeleteServiceMethodController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteServiceMethodUrl, Name = Routes.DeleteServiceMethodName)]

        public async Task<ActionResult<ErrorOr<ServiceMethod>>> Delete(DeleteServiceMethodCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record DeleteServiceMethodCommand(int Id) : IRequest<ErrorOr<ServiceMethod>>;

    internal sealed class DeleteServiceMethodCommandValidator : AbstractValidator<DeleteServiceMethodCommand>
    {
        public DeleteServiceMethodCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }

    internal sealed class DeleteServiceMethodCommandHandler(ImtApplicationDbContext context) : IRequestHandler<DeleteServiceMethodCommand, ErrorOr<ServiceMethod>>
    {
        private readonly ImtApplicationDbContext _context = context;

        public async Task<ErrorOr<ServiceMethod>> Handle(DeleteServiceMethodCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}