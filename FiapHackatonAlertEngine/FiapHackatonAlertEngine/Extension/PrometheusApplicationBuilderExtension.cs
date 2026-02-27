using Prometheus;

namespace FiapHackatonAlertEngine.WebAPI.FiapHackatonAlertEngine.Extension;

public static class PrometheusApplicationBuilderExtension
{
    public static IApplicationBuilder UsePrometheusMonitoring(this IApplicationBuilder app)
    {
        app.UseHttpMetrics(options =>
        {
            options.AddCustomLabel("service", _ => "alert-engine");
        });

        return app;
    }

    public static IEndpointRouteBuilder MapPrometheusMetrics(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapMetrics();
        return endpoints;
    }
}
