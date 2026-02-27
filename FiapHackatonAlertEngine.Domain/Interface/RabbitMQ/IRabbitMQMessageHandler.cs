namespace FiapHackatonAlertEngine.Domain.Interface.RabbitMQ;

public interface IRabbitMQMessageHandler
{
    string QueueName { get; }

    Task HandleAsync(string message);
}
