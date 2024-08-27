using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using static Admin.App.Application.Features.Mtts.MttsDelete;

namespace Admin.App.Application.Features.Regions
{
    public class DeleteRegionController : ApiControllerBase
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteRegionUrl, Name = Routes.DeleteRegionName)]
        public async Task<bool> Delete(uint id)
        {
            return await Mediator.Send(new DeleteRegionCommand(id)).ConfigureAwait(false);
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
            private readonly ICurrentUserService _user;
            private readonly IImtRegionRepository _repository;
            public DeleteRegionCommandHandler(ICurrentUserService user, IImtRegionRepository repository)
            {
                _user = user;
                _repository = repository;
            }

            public async Task<bool> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
            {
                if (request.id > 0)
                {
                    var regions = _repository.GetByUintId(request.id);

                    if (regions != null)
                    {
                        return await _repository.DeleteAsync(regions);
                    }

                    return await _repository.DeleteAsync(regions);
                }

                return false;
            }
        }
    }
}
