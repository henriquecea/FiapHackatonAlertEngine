using Microsoft.Extensions.DependencyInjection;

namespace FiapHackatonAlertEngine.WebAPI.FiapHackatonAlertEngine.Extension
{

    public static class PrometheusServiceCollectionExtension
    {
        public static IServiceCollection AddPrometheusMonitoring(this IServiceCollection services)
        {
            // Aqui você poderia futuramente configurar:
            // - métricas custom globais
            // - métricas de background services
            // - collectors adicionais

            return services;
        }
    }
}
