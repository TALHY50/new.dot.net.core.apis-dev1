using ACL.Business.Contracts.Responses;
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

    public class GetByIdQueryValidator : AbstractValidator<GetCorridorByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Corridor Id is required");
        }
    }

    public class GetCorridorByIdQueryHandler :
        IRequestHandler<GetCorridorByIdQuery, ErrorOr<Corridor>>
    {
        private readonly IImtCorridorRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetCorridorByIdQueryHandler(IHttpContextAccessor httpContextAccessor, IImtCorridorRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }
        public async Task<ErrorOr<Corridor>> Handle(GetCorridorByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.FindById(request.id);
            if (entity == null)
            {
                return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            return entity;
        }
    }
}
