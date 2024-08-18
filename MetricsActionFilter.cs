using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebAPIDemo
{
    public class MetricsActionFilter : IActionFilter
    {
        private readonly ILogger<MetricsActionFilter> logger;
        private Stopwatch? stopwatch;

        public MetricsActionFilter(ILogger<MetricsActionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();

            logger.LogInformation("Starting request: {method} {url} at {time}",
                context.HttpContext.Request.Method,
                context.HttpContext.Request.Path,
                DateTime.UtcNow);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (stopwatch != null)
                stopwatch.Stop();

            logger.LogInformation("Finished request: {method} {url} at {time} and took {elapsed} ms.",
                context.HttpContext.Request.Method,
                context.HttpContext.Request.Path,
                DateTime.UtcNow,
                stopwatch?.ElapsedMilliseconds.ToString() ?? "unknown");
        }
    }
}
