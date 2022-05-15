using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TaxiDispatcher.ConsoleClient;
using TaxiDispatcher.ConsoleClient.ApiHelpers;

var builder = new ConfigurationBuilder();

IConfiguration config = builder
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddHttpClient();
        services.AddTransient<ITaxiDispatcherApiClient, TaxiDispatcherApiClient>();
    })
    .UseSerilog()
    .Build();

ConsoleClient cc = ActivatorUtilities.CreateInstance<ConsoleClient>(host.Services);
cc.Run().Wait();