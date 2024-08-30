using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Contracts.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Admin.App.Application.Features.BusinessHourAndWeekend;

public class GetBusinessHourAndWeekendByIdController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetBusinessHourAndWeekendByIdUrl, Name = Routes.GetBusinessHourAndWeekendByIdName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekend>>> Get(uint id)
    {

        var result = await Mediator.Send(new GetBusinessHourAndWeekendByIdCommand(id)).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }

    public record GetBusinessHourAndWeekendByIdCommand(uint Id) : IRequest<ErrorOr<BusinessHoursAndWeekend>>;

    public class GetBusinessHourAndWeekendByIdCommandValidator : AbstractValidator<GetBusinessHourAndWeekendByIdCommand>
    {
        public GetBusinessHourAndWeekendByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class GetBusinessHourAndWeekendByIdHandler(ApplicationDbContext _context, IBusinessHourAndWeekendRepository repository) : IRequestHandler<GetBusinessHourAndWeekendByIdCommand, ErrorOr<BusinessHoursAndWeekend>>
    {
        public async Task<ErrorOr<BusinessHoursAndWeekend>> Handle(GetBusinessHourAndWeekendByIdCommand request, CancellationToken cancellationToken)
        {

            var businessHourAndWeekend = await _context.ImtBusinessHoursAndWeekends.FirstAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (businessHourAndWeekend == null)
            {
                return Error.NotFound("Business hour and weekend not found!", ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            return businessHourAndWeekend;
        }
    }



}
