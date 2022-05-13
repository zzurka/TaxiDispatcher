using MediatR;

namespace TaxiDispatcher.Application.Taxi.Queries
{
    public class GetDriverEarningsQuery : IRequest<string>
    {
        public int Id { get; set; }
    }
}
