namespace FiapHackatonAlertEngine.Infrastructure.Repository;

public class SimulationRepository(AppDbContext context) : Repository<SensorData>(context), ISimulationRepository
{

}
