using Mapster;
using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Application.DTO
{
    public class TaxiDto : IRegister
    {
        public Guid Id { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public TaxiCompanyDto TaxiCompany { get; set; } = null!;
        public int Location { get; set; }
        
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Taxi, TaxiDto>().TwoWays();
        }
    }
}
