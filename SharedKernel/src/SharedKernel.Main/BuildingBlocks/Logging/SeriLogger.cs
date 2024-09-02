using DotNetEnv;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;

namespace SharedKernel.Main.BuildingBlocks.Logging
{
    public static class SeriLogger
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
            (context, configuration) =>
            {
                Env.NoClobber().TraversePath().Load();
                var logChannel = Env.GetString("LOG_CHANNEL") ?? context.Configuration.GetValue<string>("Logging:LogChannel");
                var elasticUri = Env.GetString("ELASTICSEARCH_URI") ?? context.Configuration.GetValue<string>("ElasticConfiguration:Uri");
                var enableElasticSearch = logChannel == "elasticsearch";
                var logFilePath = Env.GetString("LOG_FILE_PATH") ?? context.Configuration.GetValue<string>("Logging:FilePath");
                var enableFileLogging = logChannel == "file";

                configuration
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Debug()
                    .WriteTo.Console();

                // Conditionally add Elasticsearch sink
                if (enableElasticSearch && !string.IsNullOrEmpty(elasticUri))
                {
                    configuration.WriteTo.Logger(lc => lc
                        .Filter.ByIncludingOnly(evt => evt.Level >= LogEventLevel.Information) // Adjust log level here
                        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                        {
                            IndexFormat = $"sys-app-logs-{context.HostingEnvironment.ApplicationName?.ToLowerInvariant().Replace(".", "-")}" +
                                          $"-{context.HostingEnvironment.EnvironmentName?.ToLowerInvariant().Replace(".", "-")}" +
                                          $"-{DateTime.UtcNow:yyyy-MM}",
                            AutoRegisterTemplate = true,
                            NumberOfShards = 2,
                            NumberOfReplicas = 1
                        }));
                }

                // Conditionally add File sink
                if (enableFileLogging && !string.IsNullOrEmpty(logFilePath))
                {

                    configuration.WriteTo.Logger(lc => lc
                        //.ReadFrom.Configuration(context.Configuration));
                    .Filter.ByIncludingOnly(evt => evt.Level >= LogEventLevel.Information) // Adjust log level here
                    .WriteTo.File(new JsonFormatter(), logFilePath, rollingInterval: RollingInterval.Day));
                }

                configuration
                    .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                    .Enrich.WithProperty("ContentRootPath", context.HostingEnvironment.ContentRootPath)
                    .Enrich.WithEnvironmentName()
                    .ReadFrom.Configuration(context.Configuration);
            };
    }
}
