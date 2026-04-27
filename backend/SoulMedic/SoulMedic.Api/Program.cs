using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MediatR;
using SoulMedic.Api.Data;
using SoulMedic.Api.Providers.Specialists;
using SoulMedic.Api.Providers.Spercializations;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder);

var app = builder.Build();

// Uruchom migracje i seeda przed wystartowaniem aplikacji
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        // Jeśli używasz migracji EF Core:
        await context.Database.MigrateAsync();
        await DataSeeder.SeedAsync(context);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Błąd podczas migracji/seeda bazy danych.");
        throw;
    }
}

ConfigurePipeline(app);

app.Run();



// ==========================
// METODY POMOCNICZE
// ==========================
void AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Rejestracja MediatR (obsługa handlerów w tej samej aplikacji)
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<ISpecialistProvider, SpecialistProvider>();
    builder.Services.AddScoped<ISpecializationProvider, SpecializationProvider>();
}

void ConfigurePipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}