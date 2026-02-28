using FiapHackatonAlertEngine.Application.Helper;
using FiapHackatonAlertEngine.Domain.Entity;
using FiapHackatonAlertEngine.Domain.Interface.RabbitMQ;
using FiapHackatonAlertEngine.Domain.Interface.Repository;
using Prometheus;

namespace FiapHackatonAlertEngine.Application.Services.RabbitMQ;

public class RabbitMQReceiver(IAlertEngineRepository alertRepository) : IRabbitMQReceiver
{
    public async Task HandleAsync(string plotId)
    {
        if (!Guid.TryParse(plotId, out Guid plotGuidId))
            throw new ArgumentException("plotId inválido");

        var sensorDataList = await alertRepository
            .GetSensorDataByPlotIdAsync(plotGuidId);

        if (sensorDataList == null || sensorDataList.Count == 0)
            return;

        var orderedData = sensorDataList
            .OrderByDescending(x => x.CreationTime)
            .ToList();

        CheckAverageSoilMoistureLow(orderedData);
        CheckAverageSoilMoistureHigh(orderedData);
        CheckAverageTemperatureHigh(orderedData);
        CheckAverageTemperatureLow(orderedData);
        CheckAveragePrecipitationHigh(orderedData);
    }

    /// <summary>
    /// Média de Temperatura Baixa
    /// </summary>
    /// <param name="data"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void CheckAverageSoilMoistureLow(List<SensorData> data)
    {
        var avg = data.Take(25).Average(x => x.SoilMoisture);

        if (avg < 25)
            MetricsRegistry.SoilMoistureLowCounter.Inc();
    }

    /// <summary>
    /// Média de Umidade Alta
    /// </summary>
    /// <param name="data"></param>
    private void CheckAverageSoilMoistureHigh(List<SensorData> data)
    {
        var avg = data.Take(25).Average(x => x.SoilMoisture);

        if (avg > 80)
            MetricsRegistry.SoilMoistureHighCounter.Inc();
    }

    /// <summary>
    /// Média de Temperatura Alta
    /// </summary>
    /// <param name="data"></param>
    private void CheckAverageTemperatureHigh(List<SensorData> data)
    {
        var avg = data.Take(25).Average(x => x.Temperature);

        if (avg > 35)
            MetricsRegistry.TemperatureHighCounter.Inc();
    }

    /// <summary>
    /// Média de Temperatura Baixa
    /// </summary>
    /// <param name="data"></param>
    private void CheckAverageTemperatureLow(List<SensorData> data)
    {
        var avg = data.Take(25).Average(x => x.Temperature);

        if (avg < 5)
            MetricsRegistry.TemperatureLowCounter.Inc();
    }

    /// <summary>
    /// Média de Precipitação Alta
    /// </summary>
    /// <param name="data"></param>
    private void CheckAveragePrecipitationHigh(List<SensorData> data)
    {
        var avg = data.Take(25).Average(x => x.PrecipitationLevel);

        if (avg > 50)
            MetricsRegistry.PrecipitationHighCounter.Inc();
    }
}
