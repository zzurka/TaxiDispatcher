using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.DTO;

namespace TaxiDispatcher.Application.Rides.Queries
{
    public class GetRideByIdQuery : IRequestWrapper<RideDto>
    {
        public Guid Id { get; set; }
    }
}
