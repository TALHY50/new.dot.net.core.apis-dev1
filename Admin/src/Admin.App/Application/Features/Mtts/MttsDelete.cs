using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;

namespace Admin.App.Application.Features.Mtts
{
    public class MttsDelete : ApiControllerBase
    {
        [Tags("Mtt")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(AdminRoute.DeleteMttsRouteUrl, Name = AdminRoute.DeleteMttsRouteName)]
        public async Task<bool> Delete(DeleteMttCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        public record DeleteMttCommand(uint id)
           : IRequest<bool>;


        internal sealed class DeleteMttCommandValidator : AbstractValidator<DeleteMttCommand>
        {
            public DeleteMttCommandValidator()
            {
                RuleFor(r => r.id).NotEmpty();
            }
        }

        internal sealed class DeleteMttCommandHandler : IRequestHandler<DeleteMttCommand, bool>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtMttsRepository _repository;

            public DeleteMttCommandHandler(ICurrentUserService user, IImtMttsRepository repository)
            {
                _user = user;
                _repository = repository;
            }

            public async Task<bool> Handle(DeleteMttCommand request, CancellationToken cancellationToken)
            {
                if (request.id > 0)
                {
                    var entity = _repository.GetByUintId(request.id);

                    if (entity != null)
                    {
                        return await _repository.DeleteAsync(entity);
                    }

                    return await _repository.DeleteAsync(entity);
                }

                return false;
            }
        }
    }
}
