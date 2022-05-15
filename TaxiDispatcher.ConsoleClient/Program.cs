using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxiDispatcher.ConsoleClient;
using TaxiDispatcher.ConsoleClient.ApiHelpers;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<ITaxiDispatcherApiClient, TaxiDispatcherApiClient>();
    })
    .Build();

ConsoleClient svc = ActivatorUtilities.CreateInstance<ConsoleClient>(host.Services);
svc.Run(host.Services).Wait();