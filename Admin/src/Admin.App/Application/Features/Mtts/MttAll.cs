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
    public class MttsAll : ApiControllerBase
    {
        [Tags("Mtt")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(AdminRoute.AllMttsRouteUrl, Name = AdminRoute.AllMttsRouteName)]
        public async Task<ActionResult<ErrorOr<List<Mtt>>>> GetAll()
        {
            return await Mediator.Send(new GetAllMttsQuery()).ConfigureAwait(false);
        }

        public record GetAllMttsQuery() : IRequest<ErrorOr<List<Mtt>>>;



        internal sealed class Handler : IRequestHandler<GetAllMttsQuery, ErrorOr<List<Mtt>>>
        {
            private readonly IMTTRepository _repository;

            public Handler(IMTTRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<List<Mtt>>> Handle(GetAllMttsQuery request, CancellationToken cancellationToken)
            {
                return _repository.GetAll().ToList();
            }
        }
    }
}
