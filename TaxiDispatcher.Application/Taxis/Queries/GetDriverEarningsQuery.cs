using TaxiDispatcher.Application.Common.Interfaces;

namespace TaxiDispatcher.Application.Taxis.Queries
{
    public class GetDriverEarningsQuery : IRequestWrapper<string>
    {
        public int Id { get; set; }
    }
}
