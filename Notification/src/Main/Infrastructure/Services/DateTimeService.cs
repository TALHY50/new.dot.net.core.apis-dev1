using Newtonsoft.Json;

using Notification.Main.Application.Common.Interfaces;

namespace Notification.Application.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}