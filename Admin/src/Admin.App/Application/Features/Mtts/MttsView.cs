using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Security;
using static Admin.App.Application.Features.Countries.GetCountryByIdController;
using static Admin.App.Application.Features.Mtts.MttsCreate;

namespace Admin.App.Application.Features.Mtts
{
    public class MttsView : ApiControllerBase
    {
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
                return _repository.GetByUintId(request.id);
            }
        }
    }
}
