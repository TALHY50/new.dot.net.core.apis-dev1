﻿using System.Globalization;

using CsvHelper.Configuration;

using SharedKernel.Main.Domain.Todos;

namespace SharedKernel.Main.Infrastructure.Files;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    //public TodoItemRecordMap()
    //{
    //    AutoMap(CultureInfo.InvariantCulture);

    //    Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    //}
}