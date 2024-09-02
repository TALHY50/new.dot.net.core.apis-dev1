using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedKernel.Main.Infrastructure.Services;

public class DateTime : IDateTime
{
    public System.DateTime Now => System.DateTime.UtcNow;
}