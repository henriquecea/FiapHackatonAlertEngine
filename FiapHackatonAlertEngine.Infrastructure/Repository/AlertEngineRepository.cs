using FiapHackatonAlertEngine.Domain.Entity;
using FiapHackatonAlertEngine.Domain.Interface.Repository;
using FiapHackatonAlertEngine.Infrastructure.Data;

namespace FiapHackatonAlertEngine.Infrastructure.Repository;

public class AlertEngineRepository(AppDbContext context) : Repository<SensorData>(context), IAlertEngineRepository
{

}
