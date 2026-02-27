using FiapHackatonAlertEngine.Domain.Interface.Service;

namespace FiapHackatonAlertEngine.WebAPI.Background;

public class AlertEngineJob(IAlertEngineService alertService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await alertService.SearchAllPlotsAndSendMessage();
            }
            catch (Exception ex)
            {

            }

            // Espera 5 minutos
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}
