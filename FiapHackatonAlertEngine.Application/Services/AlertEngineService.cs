using FiapHackatonAlertEngine.Domain.Interface.Repository;
using FiapHackatonAlertEngine.Domain.Interface.Service;

namespace FiapHackatonAlertEngine.Application.Services;

public class AlertEngineService(IAlertEngineRepository alertRepository,
                                IRabbitMQService rabbitMQService) : IAlertEngineService
{
    public async Task SearchAllPlotsAndSendMessage()
    {
        var allPlotsId = await alertRepository.GetDistinctPlotIdsAsync();

        foreach (var item in allPlotsId)
            await rabbitMQService.PublishAsync("alert-queue", item);
    }
}
