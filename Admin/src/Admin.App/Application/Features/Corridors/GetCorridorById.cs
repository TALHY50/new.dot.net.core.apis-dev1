using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Corridors
{
    public class GetCorridorById : ApiControllerBase
    {
        [Tags("Corridor")]
        //[Authorize]
        [HttpGet(Routes.GetCorridorByIdUrl, Name = Routes.GetCorridorByIdName)]
        public async Task<ActionResult<ErrorOr<Corridor>>> GetById(uint id)
        {
            var result = await Mediator.Send(new GetCorridorByIdQuery(id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
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
            var entity = _repository.GetByUintId(request.id);
            if (entity == null)
            {
                return Error.NotFound(description: "Corridor not found!", code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            return entity;
        }
    }
}
