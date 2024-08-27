﻿using System.Globalization;
using CsvHelper.Configuration;
using SharedKernel.Main.Notification.Domain.Entities.Todos;

namespace SharedKernel.Main.Infrastructure.Files;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}