using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.BusinessHourAndWeekend;

public class GetBusinessHourAndWeekendByIdController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetBusinessHourAndWeekendByIdUrl, Name = Routes.GetBusinessHourAndWeekendByIdName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekend>>> Get(uint id)
    {
        return await Mediator.Send(new GetBusinessHourAndWeekendByIdCommand(id)).ConfigureAwait(false);
    }

    public record GetBusinessHourAndWeekendByIdCommand(uint Id) : IRequest<ErrorOr<BusinessHoursAndWeekend>>;

    public class GetBusinessHourAndWeekendByIdCommandValidator : AbstractValidator<GetBusinessHourAndWeekendByIdCommand>
    {
        public GetBusinessHourAndWeekendByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class GetBusinessHourAndWeekendByIdHandler(ImtApplicationDbContext _context, IBusinessHourAndWeekendRepository repository) : IRequestHandler<GetBusinessHourAndWeekendByIdCommand, ErrorOr<BusinessHoursAndWeekend>>
    {
        public async Task<ErrorOr<BusinessHoursAndWeekend>> Handle(GetBusinessHourAndWeekendByIdCommand request, CancellationToken cancellationToken)
        {

            var businessHourAndWeekend = await _context.ImtBusinessHoursAndWeekends.FirstAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (businessHourAndWeekend == null)
            {
                return Error.NotFound("Business hour and weekend not found!");
            }
            return businessHourAndWeekend;
        }
    }



}
