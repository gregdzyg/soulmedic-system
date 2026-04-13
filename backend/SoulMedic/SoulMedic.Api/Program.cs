using Microsoft.EntityFrameworkCore;
using SoulMedic.Api.Data;

var builder = WebApplication.CreateBuilder(args);

AddServices(builder);

var app = builder.Build();

ConfigurePipeline(app);

app.Run();


// ==========================
// METODY POMOCNICZE
// ==========================

void AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
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