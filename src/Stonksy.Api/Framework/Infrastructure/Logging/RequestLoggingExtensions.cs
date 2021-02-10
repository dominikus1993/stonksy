using System;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;

namespace Stonksy.Api.Framework.Infrastructure.Logging
{
    public static class RequestLoggingExtensions
    {
        public static LogEventLevel CustomGetLevel(HttpContext ctx, double _, Exception? ex) =>
            ex != null
                ? LogEventLevel.Error
                : ctx.Response.StatusCode > 499
                    ? LogEventLevel.Error
                    : LogEventLevel.Debug; //Debug instead of Information

        private static bool IsHealthCheckEndpoint(HttpContext ctx)
        {
            var endpoint = ctx.GetEndpoint();
            if (endpoint != null) // same as !(endpoint is null)
            {
                return string.Equals(
                    endpoint.DisplayName,
                    "Health checks",
                    StringComparison.Ordinal);
            }

            // No endpoint, so not a health check endpoint
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LogEventLevel ExcludeHealthChecks(HttpContext ctx, double _, Exception? ex) =>
            ex is not null ? LogEventLevel.Error :
            ctx.Response.StatusCode > 499 ? LogEventLevel.Error :
            IsHealthCheckEndpoint(ctx) ? LogEventLevel.Verbose : LogEventLevel.Information;

        public static void EnrichFromRequest(
            IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
            var request = httpContext.Request;
            diagnosticContext.Set("Host", request.Host);
            diagnosticContext.Set("Protocol", request.Protocol);
            diagnosticContext.Set("Scheme", request.Scheme);

            if (request.QueryString.HasValue)
            {
                diagnosticContext.Set("QueryString", request.QueryString.Value);
            }

            diagnosticContext.Set("ContentType", httpContext.Response.ContentType);

            if (IsAuthenticatedRequest(httpContext.User.Identity))
            {
                // TODO Add auth
                diagnosticContext.Set("UserId", "ABC");
            }

            var endpoint = httpContext.GetEndpoint();
            if (endpoint != null)
            {
                diagnosticContext.Set("EndpointName", endpoint.DisplayName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsAuthenticatedRequest(IIdentity? identity)
        {
            return identity?.IsAuthenticated ?? false;
        }

        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging(opts =>
            {
                opts.EnrichDiagnosticContext = EnrichFromRequest;
                opts.GetLevel = ExcludeHealthChecks; // Use the custom level
            });


            return app;
        }
    }
}