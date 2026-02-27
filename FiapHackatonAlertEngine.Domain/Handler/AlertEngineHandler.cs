using FiapHackatonAlertEngine.Domain.Interface.RabbitMQ;
using Newtonsoft.Json;

namespace FiapHackatonAlertEngine.Domain.Handler;

public class AlertEngineHandler(IRabbitMQReceiver receiver) : IRabbitMQMessageHandler
{
    public string QueueName => "alert-queue";

    public async Task HandleAsync(string message)
    {
        var alertMessage = JsonConvert.DeserializeObject<string>(message)
                         ?? throw new Exception("Mensagem inválida");

        await receiver.HandleAsync(alertMessage);
    }
}
