using Prometheus;

namespace FiapHackatonAlertEngine.Application.Helper;

public static class MetricsRegistry
{
    public static readonly Counter SoilMoistureLowCounter = Metrics
        .CreateCounter("soil_moisture_low_total", "Número de alertas de baixa umidade do solo");

    public static readonly Counter SoilMoistureHighCounter = Metrics
        .CreateCounter("soil_moisture_high_total", "Número de alertas de alta umidade do solo");

    public static readonly Counter TemperatureHighCounter = Metrics
        .CreateCounter("temperature_high_total", "Número de alertas de temperatura alta");

    public static readonly Counter TemperatureLowCounter = Metrics
        .CreateCounter("temperature_low_total", "Número de alertas de temperatura baixa");

    public static readonly Counter PrecipitationHighCounter = Metrics
        .CreateCounter("precipitation_high_total", "Número de alertas de precipitação alta");
}
