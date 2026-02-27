using FiapHackatonAlertEngine.Application.Services;
using FiapHackatonAlertEngine.Domain.Interface.Repository;
using FiapHackatonAlertEngine.Domain.Interface.Service;
using FiapHackatonAlertEngine.Infrastructure.Data;
using FiapHackatonAlertEngine.Infrastructure.Repository;
using FiapHackatonAlertEngine.WebAPI.Extension;
using FiapHackatonAlertEngine.WebAPI.FiapHackatonAlertEngine.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Serviços customizados
builder.AddSwagger();
builder.AddDbContext();
builder.AddRabbitMQ();
builder.AddAuthWithJWT();

builder.Services.AddAuthorization();
builder.Services.AddControllers()
                .AddNewtonsoftJson();

builder.Services.AddPrometheusMonitoring();

// Injeção de dependência
builder.Services.AddScoped<IAlertEngineService, AlertEngineService>();

builder.Services.AddScoped<IAlertEngineRepository, AlertEngineRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});


app.UseAuthentication();
app.UseAuthorization();

app.UsePrometheusMonitoring();
app.MapPrometheusMetrics();

app.MapControllers();

await app.RunAsync();