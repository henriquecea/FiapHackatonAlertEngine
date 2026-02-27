using FiapHackatonAlertEngine.Infrastructure.Data;
using FiapHackatonAlertEngine.WebAPI.Extension;
using FiapHackatonAlertEngine.WebAPI.FiapHackatonAlertEngine.Extension;
using Microsoft.EntityFrameworkCore;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.AddSwagger();

builder.Services.AddAuthorization();
builder.Services.AddControllers()
                .AddNewtonsoftJson();

builder.Services.AddPrometheusMonitoring();

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