using FiapHackatonAlertEngine.Domain.Entity;

namespace FiapHackatonAlertEngine.Domain.Interface.Repository;

public interface IAlertEngineRepository : IRepository<SensorData>
{
    Task<List<Guid>> GetDistinctPlotIdsAsync();

    Task<List<SensorData>> GetSensorDataByPlotIdAsync(Guid plotId);
}
