using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;
using static Admin.App.Application.Features.Regions.GetRegionController;

namespace Admin.App.Application.Features.Regions
{
    public class GetRegionByIdController : ApiControllerBase
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetRegionByIdUrl, Name = Routes.GetRegionByIdName)]
        public async Task<ActionResult<ErrorOr<Region>>> Get(uint id)
        {
            var result = await Mediator.Send(new GetRegionByIdQuery(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetRegionByIdQuery(uint id) : IRequest<ErrorOr<Region>>;

        public class GetRegionByIdCommandValidator : AbstractValidator<GetRegionByIdQuery>
        {
            public GetRegionByIdCommandValidator()
            {
                RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("ID is required");
            }
        }

        public class GetRegionByIdQueryHandler
            : IRequestHandler<GetRegionByIdQuery, ErrorOr<Region>>
        {
            private readonly IRegionRepository _repository;
            public GetRegionByIdQueryHandler(IRegionRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<Region>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
            {
                var message = new MessageResponse("Record not found");

                var region = _repository.View(request.id);

                if (region == null)
                {
                    return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
                else
                {
                    return region;
                }
            }
        }
    }

}
