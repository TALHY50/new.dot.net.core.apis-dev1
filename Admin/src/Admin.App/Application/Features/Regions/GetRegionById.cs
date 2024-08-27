using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;

namespace Admin.App.Application.Features.Regions
{
    public class GetRegionByIdController : ApiControllerBase
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetRegionByIdUrl, Name = Routes.GetRegionByIdName)]
        public async Task<ActionResult<ErrorOr<Region>>> Get(uint id)
        {
            return await Mediator.Send(new GetRegionByIdQuery(id)).ConfigureAwait(false);
        }

        public record GetRegionByIdQuery(uint id) : IRequest<ErrorOr<Region>>;

        internal sealed class GetRegionByIdCommandValidator : AbstractValidator<GetRegionByIdQuery>
        {
            public GetRegionByIdCommandValidator()
            {
                RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("Region ID is required");
            }
        }

        internal sealed class GetRegionByIdQueryHandler
            : IRequestHandler<GetRegionByIdQuery, ErrorOr<Region>>
        {
            private readonly IImtRegionRepository _repository;
            public GetRegionByIdQueryHandler(IImtRegionRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<Region>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
            {
                return _repository.GetByUintId(request.id);
            }
        }
    }

}
