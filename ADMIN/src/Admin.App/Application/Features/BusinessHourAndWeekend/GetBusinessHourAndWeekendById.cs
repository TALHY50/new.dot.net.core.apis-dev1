using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Admin;

namespace Admin.App.Application.Features.BusinessHourAndWeekend;

public class GetBusinessHourAndWeekendByIdController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetBusinessHourAndWeekendByIdUrl, Name = Routes.GetBusinessHourAndWeekendByIdName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekends>>> Delete(GetBusinessHourAndWeekendByIdCommand command, int Id)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record GetBusinessHourAndWeekendByIdCommand(int Id) : IRequest<ErrorOr<BusinessHoursAndWeekends>>;

    public class GetBusinessHourAndWeekendByIdCommandValidator : AbstractValidator<GetBusinessHourAndWeekendByIdCommand>
    {
        public GetBusinessHourAndWeekendByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class GetBusinessHourAndWeekendByIdHandler() : IRequestHandler<GetBusinessHourAndWeekendByIdCommand, ErrorOr<BusinessHoursAndWeekends>>
    {
        public Task<ErrorOr<BusinessHoursAndWeekends>> Handle(GetBusinessHourAndWeekendByIdCommand request, CancellationToken cancellationToken)
        {
            // ToDo 
            // Check this id is valid
            // Get id by model
            throw new NotImplementedException();
        }
    }



}
