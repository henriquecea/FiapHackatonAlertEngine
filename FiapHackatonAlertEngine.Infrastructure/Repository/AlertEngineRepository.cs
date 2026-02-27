using FiapHackatonAlertEngine.Domain.Entity;
using FiapHackatonAlertEngine.Domain.Interface.Repository;
using FiapHackatonAlertEngine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FiapHackatonAlertEngine.Infrastructure.Repository;

public class AlertEngineRepository(AppDbContext context) : Repository<SensorData>(context), IAlertEngineRepository
{
    public async Task<List<Guid>> GetDistinctPlotIdsAsync() =>
        await _context.Set<SensorData>()
            .Select(x => x.Plot)
            .Distinct()
            .ToListAsync();

    public async Task<List<SensorData>> GetSensorDataByPlotIdAsync(Guid plotId) =>
        await _context.Set<SensorData>()
            .Where(x => x.Plot == plotId)
            .ToListAsync();
}
