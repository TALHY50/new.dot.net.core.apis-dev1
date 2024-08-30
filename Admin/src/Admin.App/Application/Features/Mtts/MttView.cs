using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

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
            private readonly IImtMttsRepository _repository;

            public Handler(IImtMttsRepository repository)
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
