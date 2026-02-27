using FiapHackatonAlertEngine.Domain.Entity;
using FiapHackatonSimulations.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FiapHackatonAlertEngine.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SensorData> SensorData { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new SensorDataMap());
    }
}
