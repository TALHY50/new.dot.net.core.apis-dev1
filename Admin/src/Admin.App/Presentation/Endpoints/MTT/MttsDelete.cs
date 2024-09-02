using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

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


        public class DeleteMttCommandValidator : AbstractValidator<DeleteMttCommand>
        {
            public DeleteMttCommandValidator()
            {
                RuleFor(r => r.id).NotEmpty();
            }
        }

        public class DeleteMttCommandHandler : IRequestHandler<DeleteMttCommand, bool>
        {
            private readonly IMTTRepository _repository;
            public DeleteMttCommandHandler(ICurrentUser user, IMTTRepository repository)
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
