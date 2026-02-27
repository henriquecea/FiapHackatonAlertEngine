using FiapHackatonAlertEngine.Domain.DTO;
using FiapHackatonAlertEngine.Domain.Interface.RabbitMQ;
using Newtonsoft.Json;

namespace FiapHackatonAlertEngine.Domain.Handler;

public class AlertEngineHandler(IRabbitMQReceiver receiver) : IRabbitMQMessageHandler
{
    public string QueueName => "alert-queue";

    public async Task HandleAsync(string message)
    {
        var dto = JsonConvert.DeserializeObject<SimulationDto>(message);

        if (dto is not null)
            await receiver.HandleAsync(dto);
    }
}
