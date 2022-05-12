using TaxiDispatcher.Domain.Entities;

namespace TaxiDispatcher.Application.Common.Interfaces
{
    public interface ITaxiSchedulerService
    {
        Ride OrderRide(RideRequest request);
        void AcceptRide(Ride ride);
    }
}
