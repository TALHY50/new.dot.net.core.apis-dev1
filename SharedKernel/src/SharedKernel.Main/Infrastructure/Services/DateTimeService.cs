using SharedKernel.Main.Application.Common.Common.Interfaces;

namespace SharedKernel.Main.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}