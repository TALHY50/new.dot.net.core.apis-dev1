﻿using SharedKernel.Main.Application.Common.Common.Interfaces;

namespace Notification.App.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}