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
            private readonly IImtMttsRepository _repository;

            public Handler(IImtMttsRepository repository)
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
