using Mapster;
using TaxiDispatcher.Domain.Entities;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Application.DTO
{
    public class RideDto : IRegister
    {
        public Guid Id { get; set; }
        public RideRequestDto RideRequest { get; set; } = null!;
        public TaxiDto Taxi { get; set; } = null!;
        public RideStatus RideStatus { get; set; }
        public int Price { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Ride, RideDto>().TwoWays();
        }
    }
}
