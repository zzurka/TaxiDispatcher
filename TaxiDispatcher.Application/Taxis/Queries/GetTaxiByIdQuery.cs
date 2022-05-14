using TaxiDispatcher.Application.Common.Interfaces;
using TaxiDispatcher.Application.DTO;

namespace TaxiDispatcher.Application.Taxis.Queries
{
    public class GetTaxiByIdQuery : IRequestWrapper<TaxiDto>
    {
        public Guid Id { get; set; }
    }
}
