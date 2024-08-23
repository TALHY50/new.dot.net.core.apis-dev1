using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Admin.App.Application.Features.Countries
{
    public class GetCountryByIdController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetCountryByIdUrl, Name = Routes.GetCountryByIdName)]
        public async Task<ActionResult<ErrorOr<Country>>> GetById(int Id)
        {
            return await Mediator.Send(new GetCountryByIdQuery(Id)).ConfigureAwait(false);
        }

        public record GetCountryByIdQuery(int Id) : IRequest<ErrorOr<Country>>;

        internal sealed class GetCountryByIdCommandValidator : AbstractValidator<GetCountryByIdQuery>
        {
            public GetCountryByIdCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
            }
        }

        internal sealed class GetCountryByIdQueryHandler() : IRequestHandler<GetCountryByIdQuery, ErrorOr<Country>>
        {
            // get all data 
            public Task<ErrorOr<Country>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
