using ACL.Bussiness.Contracts.Responses;
using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;
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
            private readonly IImtRegionRepository _repository;
            public GetRegionByIdQueryHandler(IImtRegionRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<Region>> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
            {
                var message = new MessageResponse("Record not found");

                var region = _repository.View(request.id);

                if (region == null)
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
                else
                {
                    return region;
                }
            }
        }
    }

}
