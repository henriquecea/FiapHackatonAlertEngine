using FiapHackatonAlertEngine.WebAPI.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddSwagger();

builder.Services.AddAuthorization();
builder.Services.AddControllers()
                .AddNewtonsoftJson();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    // Aplicar migrações pendentes ao iniciar a aplicações
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

// Redirecionamento da raiz para /swagger
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
