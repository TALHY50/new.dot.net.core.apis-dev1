using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using static Admin.App.Application.Features.Mtts.MttsDelete;

namespace Admin.App.Application.Features.Regions
{
    public class DeleteRegionController : ApiControllerBase
    {
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.DeleteRegionUrl, Name = Routes.DeleteRegionName)]
        public async Task<bool> Delete(DeleteRegionCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record DeleteRegionCommand(uint id) 
        : IRequest<bool>;

    internal sealed class DeleteRegionCommandValidator : AbstractValidator<DeleteRegionCommand>
    {
        public DeleteRegionCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }

    internal sealed class DeleteRegionCommandHandler 
        : IRequestHandler<DeleteRegionCommand, bool>
    {
        public DeleteRegionCommandHandler()
        {
            
        }

        public async Task<bool> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
