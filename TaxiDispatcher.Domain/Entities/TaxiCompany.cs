using TaxiDispatcher.Domain.Common;

namespace TaxiDispatcher.Domain.Entities
{
    public class TaxiCompany : BaseEntity
    {
        public TaxiCompany(Guid id, string name, int basePrice)
        {
            Id = id;
            Name = name;
            BasePrice = basePrice;
        }

        public string Name { get; set; }
        public int BasePrice { get; set; }
    }
}
