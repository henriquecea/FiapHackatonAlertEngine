using FiapHackatonSimulations.Domain.DTO;

namespace FiapHackatonAlertEngine.Domain.Interface.RabbitMQ;

public interface IRabbitMQReceiver
{
    Task HandleAsync(SimulationDto message);
}
