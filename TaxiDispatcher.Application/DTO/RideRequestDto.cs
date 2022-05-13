using Mapster;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Application.DTO
{
    public class RideRequestDto : IRegister
    {
        public Guid Id { get; set; }
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public RideType RideType { get; set; }
        public DateTime RideTime { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Domain.Entities.RideRequest, RideRequestDto>().TwoWays();
        }
    }
}
