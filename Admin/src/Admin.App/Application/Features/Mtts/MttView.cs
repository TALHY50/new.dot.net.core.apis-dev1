using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.Mtts
{
    public class InstitutionView : ApiControllerBase
    {
          [Tags("Institution")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AdminRoute.ViewMttsRouteUrl, Name = AdminRoute.ViewMttsRouteName)]
        public async Task<ActionResult<ErrorOr<Mtt>>> GetById(uint id)
        {
            return await Mediator.Send(new GetMttsByIdQuery(id)).ConfigureAwait(false);
        }

        public record GetMttsByIdQuery(uint id) : IRequest<ErrorOr<Mtt>>;

        internal sealed class GetMttsByIdQueryValidator : AbstractValidator<GetMttsByIdQuery>
        {
            public GetMttsByIdQueryValidator()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Mtts ID is required");
            }
        }

        internal sealed class Handler : IRequestHandler<GetMttsByIdQuery, ErrorOr<Mtt>>
        {
            private readonly IMTTRepository _repository;

            public Handler(IMTTRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<Mtt>> Handle(GetMttsByIdQuery request, CancellationToken cancellationToken)
            {
                return _repository.View(request.id);
            }
        }
    }
}
