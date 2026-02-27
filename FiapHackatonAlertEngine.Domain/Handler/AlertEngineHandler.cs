using FiapHackatonAlertEngine.Domain.Interface.RabbitMQ;

namespace FiapHackatonAlertEngine.Domain.Handler;

public class AlertEngineHandler(IRabbitMQReceiver receiver) : IRabbitMQMessageHandler
{
    public string QueueName => "alert-queue";

    public async Task HandleAsync(string plotId) =>
        await receiver.HandleAsync(plotId);
}
