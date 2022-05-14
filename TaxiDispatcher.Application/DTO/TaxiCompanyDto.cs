using Mapster;
using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Application.DTO
{
    public class TaxiCompanyDto : IRegister
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BasePrice { get; set; }
        public int InterCityMultiplier { get; set; }
        public int NightRideMultiplier { get; set; }
        public int NightRideHoursFrom { get; set; }
        public int NightRideHoursTo { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TaxiCompany, TaxiCompanyDto>().TwoWays();
        }
    }
}
