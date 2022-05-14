using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.DTO;

namespace TaxiDispatcher.Application.Rides.Commands
{
    public class AcceptRideCommand : IRequestWrapper<RideDto>
    {
        public Guid Id { get; set; }
    }
}
