using MediatR;
using TaxiDispatcher.Application.DTO;

namespace TaxiDispatcher.Application.Taxi.Queries
{
    public class GetTaxiByDriverIdQuery : IRequest<TaxiDto?>
    {
        public int Id { get; set; }
    }
}
