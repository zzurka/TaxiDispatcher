using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxiDispatcher.Application.Common.Repositories;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase;
using TaxiDispatcher.Infrastructure.Persistence.InMemoryDatabase.Repositories;

namespace TaxiDispatcher.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("TaxiDispatcherDatabase"));
            
            services.AddScoped<ITaxiRepository, TaxiRepository>();
            services.AddScoped<IRideRepository, RideRepository>();

            return services;
        }
    }
}
