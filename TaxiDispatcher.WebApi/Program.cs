using AutoMapper;
using TaxiDispatcher.Application;
using TaxiDispatcher.Application.Taxi.Mappers;
using TaxiDispatcher.Infrastructure;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new TaxiMappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
