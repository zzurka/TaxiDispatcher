using MediatR;
using TaxiDispatcher.Application.DTO;

namespace TaxiDispatcher.Application.Ride.Commands
{
    public class AcceptRideCommand : IRequest<RideDto>
    {
        public Guid Id { get; set; }
    }
}
