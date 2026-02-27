using FiapHackatonAlertEngine.Domain.DTO;
using FiapHackatonAlertEngine.Domain.Interface.RabbitMQ;
using FiapHackatonAlertEngine.Domain.Interface.Repository;

namespace FiapHackatonAlertEngine.Application.Services.RabbitMQ;

public class RabbitMQReceiver(IAlertEngineRepository alertRepository) : IRabbitMQReceiver
{
    public Task HandleAsync(SimulationDto message)
    {
        throw new NotImplementedException();
    }
}
