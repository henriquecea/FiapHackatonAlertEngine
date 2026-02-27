using FiapHackatonAlertEngine.Domain.DTO;

namespace FiapHackatonAlertEngine.Domain.Interface.RabbitMQ;

public interface IRabbitMQReceiver
{
    Task HandleAsync(SimulationDto message);
}
