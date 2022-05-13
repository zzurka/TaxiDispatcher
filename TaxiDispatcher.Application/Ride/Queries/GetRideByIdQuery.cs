using MediatR;
using TaxiDispatcher.Application.DTO;

namespace TaxiDispatcher.Application.Ride.Queries
{
    public class GetRideByIdQuery : IRequest<RideDto?>
    {
        public Guid Id { get; set; }
    }
}
