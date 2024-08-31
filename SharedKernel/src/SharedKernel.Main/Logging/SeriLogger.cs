using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Formatting.Json;
using System;

namespace SharedKernel.Main.Logging;

public static class SeriLogger
{
    public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
        (context, configuration) =>
        {
            // Read environment variables or configuration
            var logChannel = Environment.GetEnvironmentVariable("LOG_CHANNEL") ?? context.Configuration.GetValue<string>("Logging:LogChannel");
            var elasticUri = Environment.GetEnvironmentVariable("ELASTICSEARCH_URI") ?? context.Configuration.GetValue<string>("ElasticConfiguration:Uri");
            var enableElasticSearch = logChannel == "elasticsearch";
            var logFilePath = Environment.GetEnvironmentVariable("LOG_FILE_PATH") ?? context.Configuration.GetValue<string>("Logging:FilePath");
            var enableFileLogging = logChannel == "file";

            configuration
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Debug()
                .WriteTo.Console();

            // Conditionally add Elasticsearch sink
            if (enableElasticSearch && !string.IsNullOrEmpty(elasticUri))
            {
                configuration.WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri(elasticUri))
                    {
                        IndexFormat = $"sys-app-logs-{context.HostingEnvironment.ApplicationName?.ToLowerInvariant().Replace(".", "-")}" +
                                      $"-{context.HostingEnvironment.EnvironmentName?.ToLowerInvariant().Replace(".", "-")}" +
                                      $"-{DateTime.UtcNow:yyyy-MM}",
                        AutoRegisterTemplate = true,
                        NumberOfShards = 2,
                        NumberOfReplicas = 1
                    });
            }

            // Conditionally add File sink
            if (enableFileLogging && !string.IsNullOrEmpty(logFilePath))
            {
                configuration.WriteTo.File(new JsonFormatter(), logFilePath, rollingInterval: RollingInterval.Day);
            }

            configuration
                .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                .Enrich.WithProperty("ContentRootPath", context.HostingEnvironment.ContentRootPath)
                .Enrich.WithEnvironmentName()
                .ReadFrom.Configuration(context.Configuration);
        };
}
