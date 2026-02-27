using FiapHackatonAlertEngine.Domain.DTO;
using FiapHackatonAlertEngine.Domain.Interface.RabbitMQ;

namespace FiapHackatonAlertEngine.Application.Services.RabbitMQ;

public class RabbitMQReceiver() : IRabbitMQReceiver
{
    public Task HandleAsync(SimulationDto message)
    {
        throw new NotImplementedException();
    }
}
