using FluentValidation.AspNetCore;
using Serilog;
using TaxiDispatcher.Application;
using TaxiDispatcher.Infrastructure;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<InMemoryDbContext>();
    await InMemoryDbContextSeed.SeedSampleData(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
