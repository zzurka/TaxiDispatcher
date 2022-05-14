using Mapster;
using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.DTO;
using TaxiDispatcher.Domain.Entities;
using TaxiDispatcher.Domain.Enums;

namespace TaxiDispatcher.Application.Rides.Commands
{
    public class RequestRideCommand : IRequestWrapper<RideDto>, IRegister
    {
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public RideType RideType { get; set; }
        public DateTime RideTime { get; set; }
        
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RequestRideCommand, RideRequest>();
        }
    }
}
