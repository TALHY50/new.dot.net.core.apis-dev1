using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.Regions
{
    public class GetRegionByIdController : ApiControllerBase
    {
        [Authorize]//(Policy = "HasPermission")]
        [HttpGet(Routes.GetRegionByIdUrl, Name = Routes.GetRegionByIdName)]
        public async Task<ActionResult<ErrorOr<Region>>> Get(int id)
        {
            return await Mediator.Send(new GetRegionByIdQuery(id)).ConfigureAwait(false);
        }

        public record GetRegionByIdQuery(int Id) : IRequest<ErrorOr<Region>>;

        internal sealed class GetRegionByIdCommandValidator : AbstractValidator<GetRegionByIdQuery>
        {
            public GetRegionByIdCommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .WithMessage("Region ID is required");
            }
        }

        internal sealed class GetRegionByIdQueryHandler() 
            : IRequestHandler<GetRegionByIdQuery, ErrorOr<Region>>
        {
            // get all data 
            public Task<ErrorOr<Region>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }

}
