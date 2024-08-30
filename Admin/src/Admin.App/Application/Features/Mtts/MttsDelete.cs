using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace Admin.App.Application.Features.Mtts
{
    public class InstitutionDelete : ApiControllerBase
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
            private readonly IImtMttsRepository _repository;
            public DeleteMttCommandHandler(ICurrentUserService user, IImtMttsRepository repository)
            {
                _repository = repository;
            }

            public async Task<bool> Handle(DeleteMttCommand request, CancellationToken cancellationToken)
            {
                return _repository.Delete(request.id);
            }
        }
    }
}
