using FiapHackatonAlertEngine.Domain.Entity;
using FiapHackatonAlertEngine.Infrastructure.Data;
using FiapHackatonSimulations.Domain.Interface.Repository;

namespace FiapHackatonAlertEngine.Infrastructure.Repository;

public class AlertEngineRepository(AppDbContext context) : Repository<SensorData>(context), IAlertEngineRepository
{

}
