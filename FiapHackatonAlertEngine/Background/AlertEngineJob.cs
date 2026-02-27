using FiapHackatonAlertEngine.Domain.Interface.Service;

namespace FiapHackatonAlertEngine.WebAPI.Background;

public class AlertEngineJob(IServiceScopeFactory scopeFactory)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = scopeFactory.CreateScope();

                var alertService = scope.ServiceProvider
                    .GetRequiredService<IAlertEngineService>();

                await alertService.SearchAllPlotsAndSendMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no AlertEngineJob: {ex.Message}");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
