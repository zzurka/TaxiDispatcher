using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.DTO;

namespace TaxiDispatcher.Application.Taxis.Queries
{
    public class GetTaxiByDriverIdQuery : IRequestWrapper<TaxiDto>
    {
        public int Id { get; set; }
    }
}
