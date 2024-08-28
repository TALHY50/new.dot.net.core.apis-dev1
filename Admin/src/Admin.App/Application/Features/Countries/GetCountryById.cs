using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using MediatR;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Countries
{
    public class GetCountryByIdController : ApiControllerBase
    {
        [Tags("Country")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetCountryByIdUrl, Name = Routes.GetCountryByIdName)]
        public async Task<ActionResult<ErrorOr<Country>>> GetById(uint Id)
        {
            var result = await Mediator.Send(new GetCountryByIdQuery(Id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetCountryByIdQuery(uint Id) : IRequest<ErrorOr<Country>>;

        public class GetCountryByIdCommandValidator : AbstractValidator<GetCountryByIdQuery>
        {
            public GetCountryByIdCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
            }
        }

        public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, ErrorOr<Country>>
        {
            private readonly IAdminCountryRepository _repository;

            public GetCountryByIdQueryHandler(IAdminCountryRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<Country>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
            {
                var country = _repository.GetByUintId(request.Id);

                if (country == null)
                {
                    return Error.NotFound(description: "Country not found!", code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return country;
            }
        }
    }
}
