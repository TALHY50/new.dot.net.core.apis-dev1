using Newtonsoft.Json;

using Notification.App.Application.Common.Interfaces;

namespace ACL.Application.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}