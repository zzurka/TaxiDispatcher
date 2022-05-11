using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Application.Interfaces
{
    public interface ITaxiSchedulerService
    {
        Ride OrderRide(RideRequest request);
        void AcceptRide(Ride ride);
    }
}
