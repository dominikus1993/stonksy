using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.SystemConsole.Themes;

namespace Stonksy.Api.Framework.Infrastructure.Logging
{
    public static class SerilogExtensions
    {
        public static IHostBuilder UseLogger(this IHostBuilder hostBuilder, string? applicationName = null)
        {
            string? appName = applicationName ?? Assembly.GetExecutingAssembly().FullName;
            return hostBuilder.UseSerilog(((context, configuration) =>
            {
                var serilogOptions = context.Configuration.GetSection("Serilog").Get<SerilogOptions>();
                if (!Enum.TryParse<LogEventLevel>(serilogOptions.MinimumLevel, true, out var level))
                {
                    level = LogEventLevel.Information;
                }

                var conf = configuration
                    .MinimumLevel.Is(level)
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning) 
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ApplicationName", appName)
                    .Enrich.WithExceptionDetails();

                conf.WriteTo.Async((logger) =>
                {
                    if (serilogOptions.ConsoleEnabled)
                    {
                        switch (serilogOptions.Format.ToLower())
                        {
                            case "elasticsearch":
                                logger.Console(new ElasticsearchJsonFormatter());
                                break;
                            case "compact":
                                logger.Console(new CompactJsonFormatter());
                                break;
                            case "colored":
                                logger.Console(theme: AnsiConsoleTheme.Code);
                                break;
                            default:
                                logger.Console(new RenderedCompactJsonFormatter());
                                break;
                        }
                    }
                    logger.Trace();
                });
            }));
        }
    }
}