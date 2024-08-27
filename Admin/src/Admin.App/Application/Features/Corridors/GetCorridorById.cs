using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Domain.Entities;

namespace Admin.App.Application.Features.Corridors
{
    public class GetCorridorById : ApiControllerBase
    {
        [Tags("Corridor")]
        //[Authorize]
        [HttpGet(Routes.GetCorridorByIdUrl, Name = Routes.GetCorridorByIdName)]
        public async Task<ActionResult<ErrorOr<Corridor>>> GetById(uint id)
        {
            return await Mediator.Send(new GetCorridorByIdQuery(id)).ConfigureAwait(false);
        }
    }
    public record GetCorridorByIdQuery(uint id) : IRequest<ErrorOr<Corridor>>;

    internal sealed class GetByIdQueryValidator : AbstractValidator<GetCorridorByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Corridor Id is required");
        }
    }

    internal sealed class GetCorridorByIdQueryHandler :
        IRequestHandler<GetCorridorByIdQuery, ErrorOr<Corridor>>
    {
        private readonly IImtCorridorRepository _repository;
        public GetCorridorByIdQueryHandler(IImtCorridorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Corridor>> Handle(GetCorridorByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByUintId(request.id);
        }
    }
}
